using Api.Contracts.Auth.Response;
using Api.Contracts.Common;
using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;
using Api.Contracts.LanguageApi;
using Api.Contracts.LanguageApi.Response;
using Api.Domain.Enums;
using Api.Domain.Model;
using Api.Utilities;
using IListExtension;
using Mapster;
using Address = Api.Domain.Model.Address;
using Equipment = Api.Domain.Model.Equipment;
using Keyword = Api.Domain.Model.Keyword;
using Laboratory = Api.Domain.Model.Laboratory;
using SocialMedia = Api.Domain.Model.SocialMedia;
using Software = Api.Domain.Model.Software;
using Status = Api.Domain.Model.Status;
using Demand = Api.Domain.Model.Demand;
using Match  = Api.Domain.Model.Match;
using Company = Api.Domain.Model.Company;

namespace Api.Extensions
{
    public static class MapsterExtension
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            TypeAdapterConfig<Person, Responsible>
                .NewConfig()
                .Ignore(dest => dest.Password);

            TypeAdapterConfig<Laboratory, Contracts.Common.Laboratory>
                .NewConfig()
                .Map(dest => dest.Keywords, source => source.Keywords.Select(k => k.Text).ToList());

            TypeAdapterConfig<Demand, Contracts.Common.Demand>
                .NewConfig()
                .Map(dest => dest.Responsible, source => source.Responsible.Adapt<Responsible>())
                .Map(dest => dest.Status, source => (Contracts.Common.Status)source.Status.Id)
                .Map(dest => dest.Keywords, source => source.Keywords.Select(k => k.Text).ToList());

            TypeAdapterConfig<Contracts.Common.Company, User>
                .NewConfig()
                .Map(dest => dest.Email, source => source.Email)
                .Map(dest => dest.Password, source => ValidationHelper.HashPassword(source.Password))
                .Map(dest => dest.Company, source => new Company
                {
                    Cnpj = ValidationHelper.FormatCnpj(source.Cnpj),
                    Name = source.Name,
                    Email = source.Email,
                    Description = source.Description
                });

            TypeAdapterConfig<(User user, Token token), LoginResponse>
                .NewConfig()
                .Map(dest => dest.Id, source => source.user.Id)
                .Map(dest => dest.Type, source => source.token.Type)
                .Map(dest => dest.Token, source => source.token.Value)
                .Map(dest => dest.Expires, source => source.token.Expires)
                .Map(dest => dest.UserType, source => source.user.Company != null ? 0 : 1);

            TypeAdapterConfig<(IList<Contracts.Common.Keyword> keywords, Contracts.Common.Laboratory laboratory), User>
                .NewConfig()
                .Ignore(dest => dest.Id)
                .Map(dest => dest.Email, source => source.laboratory.Responsible.Email)
                .Map(dest => dest.Password, source => ValidationHelper.HashPassword(source.laboratory.Responsible.Password))
                .Map(dest => dest.Laboratory, source => new Laboratory
                {
                    Name = source.laboratory.Name,
                    Code = source.laboratory.Code,
                    Description = source.laboratory.Description,
                    Certificates = source.laboratory.Certificates,
                    FoundationDate = source.laboratory.FoundationDate,
                    Responsible = source.laboratory.Responsible.Adapt<Person>(),
                    Address = source.laboratory.Address.Adapt<Address>(),
                    Softwares = source.laboratory.Softwares.Adapt<IList<Software>>(),
                    Equipments = source.laboratory.Equipments.Adapt<IList<Equipment>>(),
                    SocialMedias = source.laboratory.SocialMedias.Adapt<IList<SocialMedia>>(),
                    Keywords = source.laboratory.Keywords.Select(x => new Keyword { Text = x.ToLower(), Weight = 1})
                        .Concat(source.keywords.Select(x => new Keyword { Text = x.Text.ToLower(), Weight = x.Weight }))
                        .GroupBy(x => x.Text)
                        .Select(x => x.OrderByDescending(k => k.Weight).First())
                        .ToList()
                });

            TypeAdapterConfig<CreateDemand, Description>
                .NewConfig()
                .Map(dest => dest.Text, source => $"{source.Title}. {source.Description}. {source.Details}");

            TypeAdapterConfig<UpdateDemand, Description>
                .NewConfig()
                .Map(dest => dest.Text, source => $"{source.Title}. {source.Description}. {source.Details}");

            TypeAdapterConfig<(CreateDemand demand, IList<Laboratory> laboratories), Analyze>
                .NewConfig()
                .Map(dest => dest.Text, source => $"{source.demand.Title}. {source.demand.Description}. {source.demand.Details}")
                .Map(dest => dest.Laboratories, source => source.laboratories.Select(x => new Api.Contracts.LanguageApi.Laboratory
                {
                    Id = x.Id,
                    Keywords = x.Keywords.Select(k => new Api.Contracts.Common.Keyword
                    {
                        Text = k.Text,
                        Weight = k.Weight
                    }).ToList()
                }).ToList());

            TypeAdapterConfig<(UpdateDemand demand, IList<Laboratory> laboratories), Analyze>
                .NewConfig()
                .Map(dest => dest.Text, source => $"{source.demand.Title}. {source.demand.Description}. {source.demand.Details}")
                .Map(dest => dest.Laboratories, source => source.laboratories.Select(x => new Contracts.LanguageApi.Laboratory
                {
                    Id = x.Id,
                    Keywords = x.Keywords.Select(k => new Contracts.Common.Keyword
                    {
                        Text = k.Text,
                        Weight = k.Weight
                    }).ToList()
                }).ToList());

            TypeAdapterConfig<(CreateDemand demand, User user, Person person, IList<Status> status, IList<Contracts.Common.Keyword> keywords, IList<Laboratory> laboratories, IList<AnalyzeResponse> analysis), Demand>
                .NewConfig()
                .Ignore(dest => dest.Id)
                .Map(dest => dest.Title, source => source.demand.Title)
                .Map(dest => dest.Description, source => source.demand.Description)
                .Map(dest => dest.Department, source => source.demand.Department)
                .Map(dest => dest.Benefits, source => source.demand.Benefits)
                .Map(dest => dest.Details, source => source.demand.Details)
                .Map(dest => dest.Restrictions, source => source.demand.Restrictions)
                .Map(dest => dest.Status, source => source.status.FirstOrDefault(s => s.Id == (int)MatchStatus.Analysed))
                .Map(dest => dest.Keywords, source => source.keywords
                    .Select(x => new Keyword { Text = x.Text.ToLower(), Weight = x.Weight })
                    .Concat(source.demand.Keywords.Select(x => new Keyword { Text = x.ToLower(), Weight = 1 }))
                    .GroupBy(x => x.Text)
                    .Select(x => x.OrderByDescending(k => k.Weight).First())
                    .ToList())
                .AfterMapping((source, dest) =>
                {
                    dest.Company = source.user.Company;
                    dest.Responsible = source.person ?? source.demand.Responsible.Adapt<Person>();
                    dest.Matches = source.analysis.Select(x => new Match
                    {
                        Score = x.Score,
                        Liked = false,
                        Demand = dest,
                        Laboratory = source.laboratories.FirstOrDefault(l => l.Id == x.Id)
                    }).ToList();
                });

            TypeAdapterConfig<(Demand demand, IList<Laboratory> laboratories), UpdateDemandResponse>
                .NewConfig()
                .Map(dest => dest.Id, source => source.demand.Id)
                .Map(dest => dest.Title, source => source.demand.Title)
                .Map(dest => dest.Description, source => source.demand.Description)
                .Map(dest => dest.Department, source => source.demand.Department)
                .Map(dest => dest.Benefits, source => source.demand.Benefits)
                .Map(dest => dest.Details, source => source.demand.Details)
                .Map(dest => dest.Restrictions, source => source.demand.Restrictions)
                .Map(dest => dest.Responsible, source => source.demand.Responsible.Adapt<Responsible>())
                .Map(dest => dest.Keywords, source => source.demand.Keywords.Select(k => k.Text).ToList())
                .Map(dest => dest.Laboratories, source => source.laboratories.Select(x => new Contracts.Common.Laboratory
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList())
                .AfterMapping((source, dest) =>
                {
                    dest.Laboratories.ForEach(laboratory =>
                    {
                        laboratory.Score = source.demand.Matches.FirstOrDefault(m => m.Laboratory.Id == laboratory.Id)?.Score;
                    });
                });

            TypeAdapterConfig<(Demand demand, IList<Laboratory> laboratories, IList<AnalyzeResponse> analysis), CreateDemandResponse>
                .NewConfig()
                .Map(dest => dest.Id, source => source.demand.Id)
                .Map(dest => dest.Title, source => source.demand.Title)
                .Map(dest => dest.Description, source => source.demand.Description)
                .Map(dest => dest.Department, source => source.demand.Department)
                .Map(dest => dest.Benefits, source => source.demand.Benefits)
                .Map(dest => dest.Details, source => source.demand.Details)
                .Map(dest => dest.Restrictions, source => source.demand.Restrictions)
                .Map(dest => dest.Responsible, source => source.demand.Responsible.Adapt<Responsible>())
                .Map(dest => dest.Keywords, source => source.demand.Keywords.Select(k => k.Text).ToList())
                .Map(dest => dest.Laboratories, source => source.laboratories.Select(x => new Contracts.Common.Laboratory
                {
                    Id = x.Id,
                    Score = source.analysis.FirstOrDefault(a => a.Id == x.Id).Score,
                    Name = x.Name
                }).ToList());

            return services;
        }
    }
}
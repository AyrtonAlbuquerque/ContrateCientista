using Api.Contracts.Auth;
using Api.Contracts.Common;
using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;
using Api.Contracts.LanguageApi;
using Api.Contracts.LanguageApi.Response;
using Api.Domain.Model;
using Api.Utilities;
using Mapster;
using Address = Api.Domain.Model.Address;
using Equipment = Api.Domain.Model.Equipment;
using Keyword = Api.Domain.Model.Keyword;
using Laboratory = Api.Domain.Model.Laboratory;
using SocialMedia = Api.Domain.Model.SocialMedia;
using Software = Api.Domain.Model.Software;

namespace Api.Extensions
{
    public static class MapsterExtension
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            TypeAdapterConfig<Person, Responsible>
                .NewConfig()
                .Ignore(dest => dest.Password);

            TypeAdapterConfig<RegisterCompany, User>
                .NewConfig()
                .Map(dest => dest.Email, source => source.Email)
                .Map(dest => dest.Password, source => ValidationHelper.HashPassword(source.Password))
                .Map(dest => dest.Company, source => new Company
                {
                    Cnpj = ValidationHelper.FormatCNPJ(source.Cnpj),
                    Name = source.Name,
                    Email = source.Email,
                    Description = source.Description
                });

            TypeAdapterConfig<(IList<Api.Contracts.Common.Keyword> keywords, RegisterLaboratory laboratory), User>
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

            TypeAdapterConfig< (CreateDemand demand, IList<Laboratory> laboratories), Analyze>
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

            TypeAdapterConfig< (UpdateDemand demand, IList<Laboratory> laboratories), Analyze>
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

            TypeAdapterConfig<(CreateDemand demand, IList<Api.Contracts.Common.Keyword> keywords), Demand>
                .NewConfig()
                .Ignore(dest => dest.Id)
                .Map(dest => dest.Title, source => source.demand.Title)
                .Map(dest => dest.Description, source => source.demand.Description)
                .Map(dest => dest.Department, source => source.demand.Department)
                .Map(dest => dest.Benefits, source => source.demand.Benefits)
                .Map(dest => dest.Details, source => source.demand.Details)
                .Map(dest => dest.Restrictions, source => source.demand.Restrictions)
                .Map(dest => dest.Keywords, source => source.keywords
                    .Select(x => new Keyword { Text = x.Text.ToLower(), Weight = x.Weight })
                    .Concat(source.demand.Keywords.Select(x => new Keyword { Text = x.ToLower(), Weight = 1 }))
                    .GroupBy(x => x.Text)
                    .Select(x => x.OrderByDescending(k => k.Weight).First())
                    .ToList());

            TypeAdapterConfig<(Demand demand, IList<Laboratory> laboratories, IList<AnalyzeResponse> analysis), CreateDemandResponse>
                .NewConfig()
                .Map(dest => dest.Id, source => source.demand.Id)
                .Map(dest => dest.Title, source => source.demand.Title)
                .Map(dest => dest.Description, source => source.demand.Description)
                .Map(dest => dest.Department, source => source.demand.Department)
                .Map(dest => dest.Benefits, source => source.demand.Benefits)
                .Map(dest => dest.Details, source => source.demand.Details)
                .Map(dest => dest.Restrictions, source => source.demand.Restrictions)
                .Map(dest => dest.Laboratories, source => source.laboratories.Select(x => new Contracts.Common.Laboratory
                {
                    Id = x.Id,
                    Score = source.analysis.FirstOrDefault(a => a.Id == x.Id).Score,
                    Name = x.Name,
                    Code = x.Code,
                    Description = x.Description,
                    Certificates = x.Certificates,
                    FoundationDate = x.FoundationDate,
                    Responsible = x.Responsible.Adapt<Responsible>(),
                    Address = x.Address.Adapt<Contracts.Common.Address>(),
                    Softwares = x.Softwares.Adapt<IList<Contracts.Common.Software>>(),
                    Equipments = x.Equipments.Adapt<IList<Contracts.Common.Equipment>>(),
                    SocialMedias = x.SocialMedias.Adapt<IList<Contracts.Common.SocialMedia>>()
                }).ToList());

            TypeAdapterConfig<(Demand demand, IList<Laboratory> laboratories), UpdateDemandResponse>
                .NewConfig()
                .Map(dest => dest.Id, source => source.demand.Id)
                .Map(dest => dest.Title, source => source.demand.Title)
                .Map(dest => dest.Description, source => source.demand.Description)
                .Map(dest => dest.Department, source => source.demand.Department)
                .Map(dest => dest.Benefits, source => source.demand.Benefits)
                .Map(dest => dest.Details, source => source.demand.Details)
                .Map(dest => dest.Restrictions, source => source.demand.Restrictions)
                .Map(dest => dest.Laboratories, source => source.laboratories.Select(x => new Contracts.Common.Laboratory
                {
                    Id = x.Id,
                    Score = source.demand.Matches.FirstOrDefault(m => m.Id == x.Id).Score,
                    Name = x.Name,
                    Code = x.Code,
                    Description = x.Description,
                    Certificates = x.Certificates,
                    FoundationDate = x.FoundationDate,
                    Responsible = x.Responsible.Adapt<Responsible>(),
                    Address = x.Address.Adapt<Contracts.Common.Address>(),
                    Softwares = x.Softwares.Adapt<IList<Contracts.Common.Software>>(),
                    Equipments = x.Equipments.Adapt<IList<Contracts.Common.Equipment>>(),
                    SocialMedias = x.SocialMedias.Adapt<IList<Contracts.Common.SocialMedia>>()
                }).ToList());

            return services;
        }
    }
}
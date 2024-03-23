using Api.Contracts.Auth;
using Api.Domain.Model;
using Api.Utilities;
using Mapster;
using Address = Api.Domain.Model.Address;
using Equipment = Api.Domain.Model.Equipment;
using Keyword = Api.Domain.Model.Keyword;
using SocialMedia = Api.Domain.Model.SocialMedia;
using Software = Api.Domain.Model.Software;

namespace Api.Extensions
{
    public static class MapsterExtension
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
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

            TypeAdapterConfig<(ICollection<Api.Contracts.Common.Keyword> keywords, RegisterLaboratory laboratory), User>
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
                    Softwares = source.laboratory.Softwares.Adapt<ICollection<Software>>(),
                    Equipments = source.laboratory.Equipments.Adapt<ICollection<Equipment>>(),
                    SocialMedias = source.laboratory.SocialMedias.Adapt<ICollection<SocialMedia>>(),
                    Keywords = source.laboratory.Keywords.Select(x => new Keyword { Text = x.ToLower(), Weight = 1})
                        .Concat(source.keywords.Select(x => new Keyword { Text = x.Text.ToLower(), Weight = x.Weight }))
                        .GroupBy(x => x.Text)
                        .Select(x => x.OrderByDescending(k => k.Weight).First())
                        .ToList()
                });

            return services;
        }
    }
}
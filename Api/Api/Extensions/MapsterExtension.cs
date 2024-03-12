using Api.Contracts.Auth;
using Api.Domain.Model;
using Api.Utilities;
using Mapster;
using Address = Api.Domain.Model.Address;
using Equipment = Api.Domain.Model.Equipment;
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

            TypeAdapterConfig<RegisterLaboratory, User>
                .NewConfig()
                .Map(dest => dest.Email, source => source.Responsible.Email)
                .Map(dest => dest.Password, source => ValidationHelper.HashPassword(source.Responsible.Password))
                .Map(dest => dest.Laboratory, source => new Laboratory
                {
                    Name = source.Name,
                    Code = source.Code,
                    Description = source.Description,
                    Certificates = source.Certificates,
                    FoundationDate = source.FoundationDate,
                    Responsible = source.Responsible.Adapt<Person>(),
                    Address = source.Address.Adapt<Address>(),
                    Softwares = source.Softwares.Adapt<ICollection<Software>>(),
                    Equipments = source.Equipments.Adapt<ICollection<Equipment>>(),
                    SocialMedias = source.SocialMedias.Adapt<ICollection<SocialMedia>>()
                });

            return services;
        }
    }
}
using Api.Domain.Model;
using Api.Mappings.Interfaces;
using Api.Utilities;
using Mapster;
using Company = Api.Domain.Model.Company;

namespace Api.Mappings
{
    public class CompanyMapping : IMapping
    {
        public void AddMappings()
        {
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
        }
    }
}
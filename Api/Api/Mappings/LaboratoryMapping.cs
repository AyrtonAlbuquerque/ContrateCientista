using Api.Domain.Model;
using Api.Mappings.Interfaces;
using Api.Utilities;
using Mapster;

namespace Api.Mappings
{
    public class LaboratoryMapping : IMapping
    {
        public void AddMappings()
        {
            TypeAdapterConfig<Laboratory, Contracts.Common.Laboratory>
                .NewConfig()
                .Map(dest => dest.Keywords, source => source.Keywords.Select(k => k.Text).ToList());

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
        }
    }
}
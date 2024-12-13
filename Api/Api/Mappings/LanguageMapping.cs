using Api.Contracts.Demand;
using Api.Contracts.LanguageApi;
using Api.Mappings.Interfaces;
using Mapster;
using Laboratory = Api.Contracts.LanguageApi.Laboratory;
using Keyword = Api.Contracts.Common.Keyword;

namespace Api.Mappings
{
    public class LanguageMapping : IMapping
    {
        public void AddMappings()
        {
            TypeAdapterConfig<CreateDemand, Description>
                .NewConfig()
                .Map(dest => dest.Text, source => $"{source.Title}. {source.Description}. {source.Details}");

            TypeAdapterConfig<UpdateDemand, Description>
                .NewConfig()
                .Map(dest => dest.Text, source => $"{source.Title}. {source.Description}. {source.Details}");

            TypeAdapterConfig<(CreateDemand demand, IList<Domain.Model.Laboratory> laboratories), Analyze>
                .NewConfig()
                .Map(dest => dest.Text, source => $"{source.demand.Title}. {source.demand.Description}. {source.demand.Details}")
                .Map(dest => dest.Laboratories, source => source.laboratories.Select(x => new Laboratory
                {
                    Id = x.Id,
                    Keywords = x.Keywords.Select(k => new Keyword
                    {
                        Text = k.Text,
                        Weight = k.Weight
                    }).ToList()
                }).ToList());

            TypeAdapterConfig<(UpdateDemand demand, IList<Domain.Model.Laboratory> laboratories), Analyze>
                .NewConfig()
                .Map(dest => dest.Text, source => $"{source.demand.Title}. {source.demand.Description}. {source.demand.Details}")
                .Map(dest => dest.Laboratories, source => source.laboratories.Select(x => new Laboratory
                {
                    Id = x.Id,
                    Keywords = x.Keywords.Select(k => new Keyword
                    {
                        Text = k.Text,
                        Weight = k.Weight
                    }).ToList()
                }).ToList());
        }
    }
}
using Api.Contracts.Common;
using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;
using Api.Contracts.LanguageApi.Response;
using Api.Domain.Enums;
using Api.Domain.Model;
using Api.Mappings.Interfaces;
using IListExtension;
using Mapster;
using Keyword = Api.Domain.Model.Keyword;
using Laboratory = Api.Domain.Model.Laboratory;
using Status = Api.Domain.Model.Status;
using Demand = Api.Domain.Model.Demand;
using Match  = Api.Domain.Model.Match;

namespace Api.Mappings
{
    public class DemandMapping : IMapping
    {
        public void AddMappings()
        {
            TypeAdapterConfig<Person, Responsible>
                .NewConfig()
                .Ignore(dest => dest.Password);

            TypeAdapterConfig<Demand, Contracts.Common.Demand>
                .NewConfig()
                .Map(dest => dest.Responsible, source => source.Responsible.Adapt<Responsible>())
                .Map(dest => dest.Status, source => (Contracts.Common.Status)source.Status.Id)
                .Map(dest => dest.Keywords, source => source.Keywords.Select(k => k.Text).ToList());

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
        }
    }
}
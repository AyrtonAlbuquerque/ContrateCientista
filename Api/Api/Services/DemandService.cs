using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;
using Api.Contracts.LanguageApi;
using Api.Domain.Enums;
using Api.Domain.Model;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using IListExtension;
using Mapster;

namespace Api.Services
{
    public class DemandService : IDemandService
    {
        private readonly IUserService userService;
        private readonly ILanguageService languageService;
        private readonly IPersonRepository personRepository;
        private readonly IStatusRepository statusRepository;
        private readonly IDemandRepository demandRepository;
        private readonly IKeywordRepository keywordRepository;
        private readonly ILaboratoryRepository laboratoryRepository;

        public DemandService(
            IUserService userService,
            ILanguageService languageService,
            IPersonRepository personRepository,
            IStatusRepository statusRepository,
            IDemandRepository demandRepository,
            IKeywordRepository keywordRepository,
            ILaboratoryRepository laboratoryRepository)
        {
            this.userService = userService;
            this.languageService = languageService;
            this.personRepository = personRepository;
            this.statusRepository = statusRepository;
            this.demandRepository = demandRepository;
            this.keywordRepository = keywordRepository;
            this.laboratoryRepository = laboratoryRepository;
        }

        public async Task<CreateDemandResponse> Create(CreateDemand createDemand)
        {
            var user = await userService.GetUserAsync();

            ForbiddenException.ThrowIfNull(user.Company, "Usuário não possui permissão para criar demandas");

            var status = await statusRepository.SelectAsync();
            var person = await personRepository.GetAsync(createDemand.Responsible.Email, createDemand.Responsible.Phone);
            var laboratories = await laboratoryRepository.SelectAsync();
            var keywords = await languageService.Extract(createDemand.Adapt<Description>());
            var analysis = await languageService.Analyze((createDemand, laboratories).Adapt<Analyze>());
            var demand = (createDemand, keywords).Adapt<Demand>();

            demand.Company = user.Company;
            demand.Responsible = person ?? createDemand.Responsible.Adapt<Person>();
            demand.Matches = analysis.Select(x => new Match
            {
                Score = x.Score,
                Demand = demand,
                Laboratory = laboratories.FirstOrDefault(l => l.Id == x.Id),
                Status = status.FirstOrDefault(s => s.Id == (int)MatchStatus.Analysed)
            }).ToList();

            await demandRepository.InsertAsync(demand);

            return (demand, laboratories, analysis).Adapt<CreateDemandResponse>();
        }

        public async Task<UpdateDemandResponse> Update(UpdateDemand updateDemand)
        {
            var user = await userService.GetUserAsync();
            var demand = await demandRepository.GetAsync(updateDemand.Id);

            ForbiddenException.ThrowIfNull(user.Company, "Usuário não possui permissão para criar demandas");
            NotFoundException.ThrowIfNull(demand, "Demanda não encontrada");
            ForbiddenException.ThrowIf(demand.Company != user.Company, "Usuário não possui permissão para alterar demandas de outra empresa");

            var laboratories = await laboratoryRepository.SelectAsync();
            var person = await personRepository.GetAsync(updateDemand.Responsible.Email, updateDemand.Responsible.Phone);
            var keywords = await languageService.Extract(updateDemand.Adapt<Description>());
            var analysis = await languageService.Analyze((updateDemand, laboratories).Adapt<Analyze>());

            await keywordRepository.DeleteAsync(demand.Keywords);

            demand.Title = updateDemand.Title ?? demand.Title;
            demand.Description = updateDemand.Description ?? demand.Description;
            demand.Department = updateDemand.Department ?? demand.Department;
            demand.Benefits = updateDemand.Benefits ?? demand.Benefits;
            demand.Details = updateDemand.Details ?? demand.Details;
            demand.Restrictions = updateDemand.Restrictions ?? demand.Restrictions;
            demand.Responsible = (person != demand.Responsible) ? person : demand.Responsible;
            demand.Matches.ForEach(match => match.Score = analysis.FirstOrDefault(x => x.Id == match.Laboratory.Id)?.Score ?? match.Score);
            demand.Keywords.AddRange(keywords
                .Select(x => new Keyword { Text = x.Text.ToLower(), Weight = x.Weight })
                .Concat(updateDemand.Keywords.Select(x => new Keyword { Text = x.ToLower(), Weight = 1 }))
                .GroupBy(x => x.Text)
                .Select(x => x.OrderByDescending(k => k.Weight).First()));

            await demandRepository.UpdateAsync(demand);

            return (demand, laboratories).Adapt<UpdateDemandResponse>();
        }
    }
}
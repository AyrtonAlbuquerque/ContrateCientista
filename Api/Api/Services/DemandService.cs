using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;
using Api.Contracts.LanguageApi;
using Api.Domain.Enums;
using Api.Domain.Model;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
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
        private readonly ILaboratoryRepository laboratoryRepository;

        public DemandService(
            IUserService userService,
            ILanguageService languageService,
            IPersonRepository personRepository,
            IStatusRepository statusRepository,
            IDemandRepository demandRepository,
            ILaboratoryRepository laboratoryRepository)
        {
            this.userService = userService;
            this.languageService = languageService;
            this.personRepository = personRepository;
            this.statusRepository = statusRepository;
            this.demandRepository = demandRepository;
            this.laboratoryRepository = laboratoryRepository;
        }

        public async Task<CreateDemandResponse> Create(CreateDemand createDemand)
        {
            var user = await userService.GetUserAsync();

            BadRequestException.ThrowIfNull(user.Company, "Usuário não possui permissão para criar demandas");

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
    }
}
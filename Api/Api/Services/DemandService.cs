using Api.Contracts.Demand;
using Api.Contracts.Demand.Response;
using Api.Contracts.LanguageApi;
using Api.Domain.Enums;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class DemandService : IDemandService
    {
        private readonly IUserService userService;
        private readonly ILanguageService languageService;
        private readonly IDemandRepository demandRepository;
        private readonly IKeywordRepository keywordRepository;
        private readonly ILaboratoryRepository laboratoryRepository;

        public DemandService(
            IUserService userService,
            ILanguageService languageService,
            IDemandRepository demandRepository,
            IKeywordRepository keywordRepository,
            ILaboratoryRepository laboratoryRepository)
        {
            this.userService = userService;
            this.languageService = languageService;
            this.demandRepository = demandRepository;
            this.keywordRepository = keywordRepository;
            this.laboratoryRepository = laboratoryRepository;
        }

        public async Task<CreateDemandResponse> Create(CreateDemand createDemand)
        {
            var user = await userService.GetUserAsync();

            if (user.Company == null) BadRequestException.Throw("Usuário não possui permissão para criar demandas");

            var laboratories = await laboratoryRepository.SelectAsync();
            var keywords = await languageService.ExtractGPT(new Description { Text = $"{createDemand.Title}. {createDemand.Description}. {createDemand.Details}" });

            throw new NotImplementedException();
        }
    }
}
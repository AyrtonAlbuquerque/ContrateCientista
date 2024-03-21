using Api.Contracts.LanguageApi;
using Api.Domain.Repository;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class DemandService : IDemandService
    {
        private readonly ILanguageService languageService;
        private readonly IDemandRepository demandRepository;
        private readonly IKeywordRepository keywordRepository;

        public DemandService(
            ILanguageService languageService,
            IDemandRepository demandRepository,
            IKeywordRepository keywordRepository)
        {
            this.languageService = languageService;
            this.demandRepository = demandRepository;
            this.keywordRepository = keywordRepository;
        }

        public async Task<Keyword> ExtractKeywords(Description description)
        {
            return await languageService.Extract(description);
        }
    }
}
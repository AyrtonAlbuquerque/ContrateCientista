using Api.Contracts.LanguageApi;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class DemandService : IDemandService
    {
        private readonly ILanguageService languageService;

        public DemandService(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        public async Task<Keyword> ExtractKeywords(Demand demand)
        {
            return await languageService.Extract(demand);
        }
    }
}
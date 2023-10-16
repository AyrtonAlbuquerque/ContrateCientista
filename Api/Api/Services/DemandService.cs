using Api.Contracts.LanguageApi;
using Api.Domain.Data;
using Api.Services.Interfaces;

namespace Api.Services
{
    public class DemandService : IDemandService
    {
        private readonly DataContext context;
        private readonly ILanguageService languageService;

        public DemandService(DataContext context, ILanguageService languageService)
        {
            this.context = context;
            this.languageService = languageService;
        }

        public async Task<Keyword> ExtractKeywords(Demand demand)
        {
            return await languageService.Extract(demand);
        }
    }
}
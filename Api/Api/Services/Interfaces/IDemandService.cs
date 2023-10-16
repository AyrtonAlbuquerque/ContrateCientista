using Api.Contracts.LanguageApi;

namespace Api.Services.Interfaces
{
    public interface IDemandService
    {
        Task<Keyword> ExtractKeywords(Demand demand);
    }
}
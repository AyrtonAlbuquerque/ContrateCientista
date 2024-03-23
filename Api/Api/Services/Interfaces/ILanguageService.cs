using Refit;
using Api.Contracts.Common;
using Api.Contracts.LanguageApi;

namespace Api.Services.Interfaces
{
    public interface ILanguageService
    {
        [Post("/language/extractBERT")]
        Task<ICollection<Keyword>> ExtractBERT([Body] Description description);

        [Post("/language/extractGPT")]
        Task<ICollection<Keyword>> ExtractGPT([Body] Description description);
    }
}
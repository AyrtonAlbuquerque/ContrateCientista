using Refit;
using Api.Contracts.Common;
using Api.Contracts.LanguageApi;

namespace Api.Services.Interfaces
{
    public interface ILanguageService
    {
        [Post("/language/extractBert")]
        Task<ICollection<Keyword>> ExtractBert([Body] Description description);

        [Post("/language/extractGpt")]
        Task<ICollection<Keyword>> ExtractGpt([Body] Description description);

        [Post("/language/extractAws")]
        Task<ICollection<Keyword>> ExtractAws([Body] Description description);

        [Post("/language/extractAzure")]
        Task<ICollection<Keyword>> ExtractAzure([Body] Description description);

        [Post("/language/extractYake")]
        Task<ICollection<Keyword>> ExtractYake([Body] Description description);
    }
}
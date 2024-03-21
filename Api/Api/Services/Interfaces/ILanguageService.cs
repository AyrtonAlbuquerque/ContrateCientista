using Refit;
using Api.Contracts.LanguageApi;

namespace Api.Services.Interfaces
{
    public interface ILanguageService
    {
        [Post("/language/extract")]
        Task<Keyword> Extract([Body] Description description);
    }
}
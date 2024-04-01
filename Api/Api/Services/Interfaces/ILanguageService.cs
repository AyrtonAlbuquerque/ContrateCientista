using Refit;
using Api.Contracts.Common;
using Api.Contracts.LanguageApi;
using Api.Contracts.LanguageApi.Response;

namespace Api.Services.Interfaces
{
    public interface ILanguageService
    {
        [Post("/extract/bert")]
        Task<ICollection<Keyword>> ExtractBert([Body] Description description);

        [Post("/extract/gpt")]
        Task<ICollection<Keyword>> ExtractGpt([Body] Description description);

        [Post("/extract/aws")]
        Task<ICollection<Keyword>> ExtractAws([Body] Description description);

        [Post("/extract/azure")]
        Task<ICollection<Keyword>> ExtractAzure([Body] Description description);

        [Post("/extract/yake")]
        Task<ICollection<Keyword>> ExtractYake([Body] Description description);

        [Post("/analyze/demand")]
        Task<ICollection<AnalyzeResponse>> Analyze(Analyze analyze);
    }
}
using Refit;
using Api.Contracts.Common;
using Api.Contracts.LanguageApi;
using Api.Contracts.LanguageApi.Response;
using Api.Domain.Enums;

namespace Api.Services.Interfaces
{
    public interface ILanguageService
    {
        [Post("/extract/bert")]
        Task<IList<Keyword>> ExtractBert([Body] Description description);

        [Post("/extract/gpt")]
        Task<IList<Keyword>> ExtractGpt([Body] Description description);

        [Post("/extract/aws")]
        Task<IList<Keyword>> ExtractAws([Body] Description description);

        [Post("/extract/azure")]
        Task<IList<Keyword>> ExtractAzure([Body] Description description);

        [Post("/extract/yake")]
        Task<IList<Keyword>> ExtractYake([Body] Description description);

        [Post("/analyze/demand")]
        Task<IList<AnalyzeResponse>> Analyze([Body] Analyze analyze);

        Task<IList<Keyword>> Extract(Description description, Model? model = Model.Bert)
        {
            return model switch
            {
                Model.Gpt => ExtractGpt(description),
                Model.Aws => ExtractAws(description),
                Model.Bert => ExtractBert(description),
                Model.Yake => ExtractYake(description),
                Model.Azure => ExtractAzure(description),
                _ => ExtractBert(description)
            };
        }
    }
}
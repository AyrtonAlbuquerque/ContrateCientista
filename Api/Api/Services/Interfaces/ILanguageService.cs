using Refit;
using Api.Contracts.Common;
using Api.Contracts.LanguageApi;
using Api.Contracts.LanguageApi.Response;

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

        Task<IList<Keyword>> Extract(Description description)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var model = configuration["AppSettings:ExtractionModel"];

            return model?.ToLower() switch
            {
                "gpt" => ExtractGpt(description),
                "aws" => ExtractAws(description),
                "bert" => ExtractBert(description),
                "yake" => ExtractYake(description),
                "azure" => ExtractAzure(description),
                _ => ExtractBert(description)
            };
        }
    }
}
using Refit;
using System.Configuration;
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
        Task<ICollection<AnalyzeResponse>> Analyze([Body] Analyze analyze);

        Task<ICollection<Keyword>> Extract(Description description)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            var model = configuration["AppSettings:ExtractionModel"];

            switch (model?.ToLower())
            {
                case "gpt":
                    return ExtractGpt(description);
                case "aws":
                    return ExtractAws(description);
                case "bert":
                    return ExtractBert(description);
                case "yake":
                    return ExtractYake(description);
                case "azure":
                    return ExtractAzure(description);
                default:
                    return ExtractBert(description);
            }
        }
    }
}
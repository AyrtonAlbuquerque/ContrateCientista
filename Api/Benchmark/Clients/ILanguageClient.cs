using Benchmark.Contracts;
using Benchmark.Contracts.Responses;
using Refit;

namespace Benchmark.Clients
{
    public interface ILanguageClient
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
        Task<IList<AnalysisResponse>> Analyze([Body] Analysis analysis);

        Task<IList<Keyword>> Extract(Description description, string model)
        {
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
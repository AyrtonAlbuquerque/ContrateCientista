using System.Text.Json.Serialization;

namespace Benchmark.Contracts.Responses
{
    public class AnalysisResponse
    {
        [JsonRequired]
        [JsonPropertyName("laboratory_id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonPropertyName("score")]
        public decimal Score { get; set; }
    }
}
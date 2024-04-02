using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi.Response
{
    public class AnalyzeResponse
    {
        [JsonRequired]
        [JsonPropertyName("laboratory_id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonPropertyName("score")]
        public decimal Score { get; set; }
    }
}
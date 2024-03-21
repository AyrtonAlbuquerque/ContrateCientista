using System.Text.Json.Serialization;

namespace Api.Contracts.Demand.Response
{
    public class Keyword
    {
        [JsonRequired]
        [JsonPropertyName("word")]
        public string Word { get; set; }

        [JsonRequired]
        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }
    }
}
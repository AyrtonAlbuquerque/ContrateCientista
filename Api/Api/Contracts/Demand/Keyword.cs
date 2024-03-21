using System.Text.Json.Serialization;

namespace Api.Contracts.Demand
{
    public class Keyword
    {
        [JsonRequired]
        [JsonPropertyName("word")]
        public string Word { get; set; }
    }
}
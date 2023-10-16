using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Demand
    {
        [JsonRequired]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
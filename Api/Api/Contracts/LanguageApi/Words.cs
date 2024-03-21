using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Words
    {
        [JsonRequired]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonRequired]
        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }
    }
}
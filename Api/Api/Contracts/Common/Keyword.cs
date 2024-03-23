using System.Text.Json.Serialization;

namespace Api.Contracts.Common
{
    public class Keyword
    {
        [JsonRequired]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonRequired]
        [JsonPropertyName("weight")]
        public decimal Weight { get; set; }
    }
}
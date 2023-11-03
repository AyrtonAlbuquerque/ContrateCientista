using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Token
    {
        [JsonRequired]
        [JsonPropertyName("value")]
        public string Value { get; set; }

        [JsonRequired]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("expires")]
        public decimal? Expires { get; set; }
    }
}
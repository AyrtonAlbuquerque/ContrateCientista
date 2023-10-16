using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Token
    {
        [JsonRequired]
        [JsonPropertyName("token")]
        public string AccessToken { get; set; }

        [JsonRequired]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("expiration")]
        public decimal? Expiration { get; set; }
    }
}
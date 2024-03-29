using System.Text.Json.Serialization;

namespace Api.Contracts.Common
{
    public class SocialMedia
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonRequired]
        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}
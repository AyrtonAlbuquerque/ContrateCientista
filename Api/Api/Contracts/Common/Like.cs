using System.Text.Json.Serialization;

namespace Api.Contracts.Common
{
    public class Like
    {
        [JsonRequired]
        [JsonPropertyName("id")]
        public int Match { get; set; }

        [JsonRequired]
        [JsonPropertyName("like")]
        public bool Liked { get; set; }
    }
}
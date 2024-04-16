using System.Text.Json.Serialization;

namespace Api.Contracts.Demand
{
    public class Like
    {
        [JsonRequired]
        [JsonPropertyName("matchId")]
        public int Match { get; set; }

        [JsonRequired]
        [JsonPropertyName("like")]
        public bool Liked { get; set; }
    }
}
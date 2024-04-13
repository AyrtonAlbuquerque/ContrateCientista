using System.Text.Json.Serialization;

namespace Api.Contracts.Common
{
    public class Match
    {
        [JsonRequired]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonPropertyName("score")]
        public decimal Score { get; set; }

        [JsonRequired]
        [JsonPropertyName("liked")]
        public bool Liked { get; set; }

        [JsonRequired]
        [JsonPropertyName("laboratory")]
        public Laboratory Laboratory { get; set; }
    }
}
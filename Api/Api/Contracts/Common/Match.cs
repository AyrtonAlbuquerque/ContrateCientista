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

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("demand")]
        public Demand Demand { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("laboratory")]
        public Laboratory Laboratory { get; set; }
    }
}
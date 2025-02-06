using System.Text.Json.Serialization;

namespace Benchmark.Contracts
{
    public class Auth
    {
        [JsonRequired]
        [JsonPropertyName("userId")]
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("userType")]
        public int? UserType { get; set; }

        [JsonRequired]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonRequired]
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("expires")]
        public double? Expires { get; set; }
    }
}
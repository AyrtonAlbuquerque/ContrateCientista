using System.Text.Json.Serialization;

namespace Benchmark.Contracts
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
        public double? Expires { get; set; }
    }
}
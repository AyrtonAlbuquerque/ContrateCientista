using System.Text.Json.Serialization;

namespace Benchmark.Contracts
{
    public class Description
    {
        [JsonRequired]
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
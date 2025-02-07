using System.Text.Json.Serialization;

namespace Benchmark.Contracts
{
    public class Analysis
    {
        [JsonRequired]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonRequired]
        [JsonPropertyName("laboratories")]
        public IList<Laboratory> Laboratories { get; set; }
    }
}
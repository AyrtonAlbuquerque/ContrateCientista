using System.Text.Json.Serialization;

namespace Benchmark.Contracts
{
    public class Demand
    {
        [JsonRequired]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonRequired]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("benefits")]
        public string Benefits { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("details")]
        public string Details { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("restrictions")]
        public string Restrictions { get; set; }

        [JsonRequired]
        [JsonPropertyName("responsible")]
        public Responsible Responsible { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("keywords")]
        public IList<string> Keywords { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace Api.Contracts.Demand
{
    public class CreateDemand
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

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("keywords")]
        public ICollection<string> Keywords { get; set; }
    }
}
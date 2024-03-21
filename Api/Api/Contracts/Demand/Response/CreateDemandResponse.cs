using System.Text.Json.Serialization;

namespace Api.Contracts.Demand.Response
{
    public class CreateDemandResponse
    {
        [JsonRequired]
        [JsonPropertyName("id")]
        public int Id { get; set; }

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
        [JsonPropertyName("company")]
        public Company Company { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("keywords")]
        public ICollection<Keyword> Keywords { get; set; }
    }
}
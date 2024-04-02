using System.Text.Json.Serialization;

namespace Api.Contracts.Common
{
    public class Equipment
    {
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("area")]
        public string Area { get; set; }
    }
}
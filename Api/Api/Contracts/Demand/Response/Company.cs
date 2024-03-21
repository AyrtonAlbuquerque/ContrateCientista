using System.Text.Json.Serialization;

namespace Api.Contracts.Demand.Response
{
    public class Company
    {
        [JsonRequired]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonPropertyName("cnpj")]
        public string CNPJ { get; set; }

        [JsonRequired]
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
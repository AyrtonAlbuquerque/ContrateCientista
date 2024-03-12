using System.Text.Json.Serialization;

namespace Api.Contracts.Auth
{
    public class Responsible
    {
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonRequired]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("departament")]
        public string Departament { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }
}
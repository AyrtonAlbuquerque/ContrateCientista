using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Contracts.Auth
{
    public class RegisterCompany
    {
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; }

        [JsonRequired, EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonRequired]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
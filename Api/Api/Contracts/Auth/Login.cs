using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Contracts.Auth
{
    public class Login
    {
        [JsonRequired, EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonRequired]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
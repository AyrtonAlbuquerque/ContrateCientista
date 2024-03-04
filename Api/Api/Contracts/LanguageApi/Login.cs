using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Login
    {
        [JsonRequired]
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonRequired]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
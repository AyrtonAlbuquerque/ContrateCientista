using System.Text.Json.Serialization;

namespace Api.Contracts.Auth
{
    public class Login
    {
        [JsonRequired]
        [JsonPropertyName("login")]
        public string Usuario { get; set; }

        [JsonRequired]
        [JsonPropertyName("senha")]
        public string Senha { get; set; }
    }
}
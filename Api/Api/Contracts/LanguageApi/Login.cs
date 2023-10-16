using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Login
    {
        [JsonRequired]
        [JsonPropertyName("username")]
        public string Usuario { get; set; }

        [JsonRequired]
        [JsonPropertyName("password")]
        public string Senha { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace Api.Contracts.Auth.Response
{
    public class LoginResponse
    {
        [JsonRequired]
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("expiration")]
        public double? Expiration { get; set; }
    }
}
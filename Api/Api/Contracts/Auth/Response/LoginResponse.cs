using System.Text.Json.Serialization;

namespace Api.Contracts.Auth.Response
{
    public class LoginResponse
    {
        [JsonRequired]
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonRequired]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("expires")]
        public double? Expires { get; set; }
    }
}
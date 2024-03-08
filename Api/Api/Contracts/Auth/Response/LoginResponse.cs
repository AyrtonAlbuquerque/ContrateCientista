using System.Text.Json.Serialization;

namespace Api.Contracts.Auth.Response
{
    public class LoginResponse
    {
        [JsonRequired]
        [JsonPropertyName("userId")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonRequired]
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("expires")]
        public double? Expires { get; set; }
    }
}
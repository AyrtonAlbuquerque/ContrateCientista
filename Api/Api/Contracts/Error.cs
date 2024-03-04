using System.Text.Json.Serialization;

namespace Api.Contracts
{
    public class Error
    {
        [JsonRequired]
        [JsonPropertyName("message")]
        public virtual string Message { get; set; }
    }
}
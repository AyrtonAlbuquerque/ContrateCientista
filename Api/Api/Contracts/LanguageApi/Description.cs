using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Description
    {
        [JsonRequired]
        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
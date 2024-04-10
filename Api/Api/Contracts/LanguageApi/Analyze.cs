using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Analyze
    {
        [JsonRequired]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonRequired]
        [JsonPropertyName("laboratories")]
        public IList<Laboratory> Laboratories { get; set; }
    }
}
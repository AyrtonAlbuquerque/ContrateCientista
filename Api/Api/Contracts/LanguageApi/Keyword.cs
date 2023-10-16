using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Keyword
    {
        [JsonRequired]
        [JsonPropertyName("keywords")]
        public IEnumerable<Word> Keywords { get; set; }
    }
}
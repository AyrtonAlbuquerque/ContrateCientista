using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Keyword
    {
        [JsonRequired]
        [JsonPropertyName("keywords")]
        public ICollection<Words> Keywords { get; set; }
    }
}
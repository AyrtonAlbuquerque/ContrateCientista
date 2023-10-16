using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Word
    {
        [JsonRequired]
        [JsonPropertyName("word")]
        public string Text { get; set; }

        [JsonRequired]
        [JsonPropertyName("score")]
        public decimal Score { get; set; }
    }
}
using Api.Contracts.Common;
using System.Text.Json.Serialization;

namespace Api.Contracts.LanguageApi
{
    public class Laboratory
    {
        [JsonRequired]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonRequired]
        [JsonPropertyName("keywords")]
        public ICollection<Keyword> Keywords { get; set; }
    }
}
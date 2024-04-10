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
        public IList<Keyword> Keywords { get; set; }
    }
}
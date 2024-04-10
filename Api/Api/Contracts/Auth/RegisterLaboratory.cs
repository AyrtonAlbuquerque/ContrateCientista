using Api.Contracts.Common;
using System.Text.Json.Serialization;

namespace Api.Contracts.Auth
{
    public class RegisterLaboratory : Laboratory
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("keywords")]
        public IList<string> Keywords { get; set; }
    }
}
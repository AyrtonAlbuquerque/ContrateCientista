using System.Text.Json.Serialization;

namespace Benchmark.Contracts
{
    public class Responsible
    {
        [JsonRequired]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("departament")]
        public string Department { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }
}
using System.Text.Json.Serialization;
using CsvHelper.Configuration;

namespace Benchmark.Contracts
{
    public class Laboratory
    {
        [JsonRequired]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonRequired]
        [JsonPropertyName("keywords")]
        public IList<Keyword> Keywords { get; set; }
    }

    public class LaboratoryMap : ClassMap<Laboratory>
    {
        public LaboratoryMap()
        {
            Map(x => x.Id).Name("id");
            Map(x => x.Description).Name("description");
            Map(x => x.Keywords).Name("keywords").Convert(args => 
            {
                return args.Row.GetField("keywords")?.Split(';').Select(x => new Keyword 
                { 
                    Text = x.Trim().ToLower(),
                    Weight = 1 
                }).ToList();
            });
        }
    }
}
using CsvHelper.Configuration;

namespace Benchmark.Contracts
{
    public class Demand
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
    }

    public class DemandMap : ClassMap<Demand>
    {
        public DemandMap()
        {
            Map(x => x.Id).Name("id");
            Map(x => x.Title).Name("title");
            Map(x => x.Description).Name("description");
            Map(x => x.Details).Name("details");
        }
    }
}
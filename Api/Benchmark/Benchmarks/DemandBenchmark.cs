using System.Globalization;
using Benchmark.Clients;
using Benchmark.Contracts;
using Benchmark.Domain.Model;
using Benchmark.Domain.Repository;
using CsvHelper;
using CsvHelper.Configuration;

namespace Benchmark.Benchmarks
{
    public class DemandBenchmark(ITestsRepository testsRepository, IDemandClient demandClient)
    {
        public async Task Run()
        {
            var configuration = new CsvConfiguration(CultureInfo.InstalledUICulture)
            {
                // HasHeaderRecord = false
                PrepareHeaderForMatch = args => args.Header.ToLower()
            };

            using (var reader = new StreamReader("..\\Files\\demands.csv"))
            using (var csv = new CsvReader(reader, configuration))
            {
                var demands = csv.GetRecords<Demand>();

                foreach (var demand in demands)
                {
                    var response = await demandClient.Post(demand);

                    foreach (var laboratory in response.Laboratories)
                    {
                        await testsRepository.InsertAsync(new Tests
                        {
                            Laboratory = laboratory.Id.GetValueOrDefault(),
                            Demand = response.Id,
                            Intelligence = "",
                            Score = laboratory.Score.GetValueOrDefault()
                        });   
                    }
                }
            }
        }
    }
}
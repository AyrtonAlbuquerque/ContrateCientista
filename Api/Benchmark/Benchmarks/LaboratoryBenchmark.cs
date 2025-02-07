using System.Globalization;
using Benchmark.Clients;
using Benchmark.Contracts;
using Benchmark.Domain.Repository;
using CsvHelper;
using CsvHelper.Configuration;

namespace Benchmark.Benchmarks
{
    public class LaboratoryBenchmark(ILaboratoryClient laboratoryClient)
    {
        public async Task Run()
        {
            var configuration = new CsvConfiguration(CultureInfo.InstalledUICulture)
            {
                // HasHeaderRecord = false
                PrepareHeaderForMatch = args => args.Header.ToLower()
            };

            using (var reader = new StreamReader("..\\Files\\laboratories.csv"))
            using (var csv = new CsvReader(reader, configuration))
            {
                var laboratories = csv.GetRecords<Laboratory>();

                foreach (var laboratory in laboratories)
                {
                    await laboratoryClient.Post(laboratory);
                }
            }
        }
    }
}
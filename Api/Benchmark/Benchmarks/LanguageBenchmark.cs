using System.Diagnostics;
using Benchmark.Clients;
using Benchmark.Contracts;
using Benchmark.Domain.Model;
using Benchmark.Domain.Repository;
using CsvHelper;
using CsvHelper.Configuration;

namespace Benchmark.Benchmarks
{
    public class LanguageBenchmark(ITestsRepository testsRepository, ILanguageClient languageClient, CsvConfiguration configuration)
    {
        public async Task Run()
        {
            var intelligences = new string[] { "aws", "gpt", "bert", "yake", "azure" };
            var tests = await testsRepository.SelectAsync();

            using (var laboratoryReader = new StreamReader("..\\..\\..\\Benchmarks\\Files\\laboratories.csv"))
            using (var demandReader = new StreamReader("..\\..\\..\\Benchmarks\\Files\\demands.csv"))
            using (var laboratoryCSV = new CsvReader(laboratoryReader, configuration))
            using (var demandCSV = new CsvReader(demandReader, configuration))
            {
                demandCSV.Context.RegisterClassMap<DemandMap>();
                laboratoryCSV.Context.RegisterClassMap<LaboratoryMap>();

                var demands = demandCSV.GetRecords<Demand>();
                var laboratories = laboratoryCSV.GetRecords<Laboratory>();

                foreach (var intelligence in intelligences)
                {
                    foreach (var demand in demands)
                    {
                        foreach (var laboratory in laboratories)
                        {
                            if (!tests.Any(x => x.Demand == demand.Id && x.Laboratory == laboratory.Id && x.Intelligence == intelligence))
                            {
                                var timer = Stopwatch.StartNew();
                                var keywords = await languageClient.Extract(new Description { Text = laboratory.Description }, intelligence);

                                timer.Stop();

                                laboratory.Keywords = laboratory.Keywords
                                    .Concat(keywords.Select(x => new Keyword { Text = x.Text.ToLower(), Weight = x.Weight }))
                                    .GroupBy(x => x.Text)
                                    .Select(x => x.OrderByDescending(k => k.Weight).First())
                                    .ToList();

                                var analysis = await languageClient.Analyze(new Analysis
                                {
                                    Text = $"{demand.Title}. {demand.Description}. {demand.Details}",
                                    Laboratories = [laboratory]
                                });

                                await testsRepository.InsertAsync(new Tests
                                {
                                    Demand = demand.Id,
                                    Laboratory = laboratory.Id,
                                    Intelligence = intelligence,
                                    Time = timer.ElapsedMilliseconds,
                                    Score = analysis.First(x => x.Id == laboratory.Id).Score
                                }); 
                            }
                        }
                    }
                }
            }
        }
    }
}
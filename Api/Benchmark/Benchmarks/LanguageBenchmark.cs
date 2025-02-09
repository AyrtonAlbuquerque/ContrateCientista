using System.Collections;
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
            var tests = await testsRepository.SelectAsync();
            var intelligences = new string[] { "yake", "bert", "aws", "azure", "gpt" };

            using (var laboratoryReader = new StreamReader("..\\..\\..\\Benchmarks\\Files\\laboratories.csv"))
            using (var demandReader = new StreamReader("..\\..\\..\\Benchmarks\\Files\\demands.csv"))
            using (var laboratoryCsv = new CsvReader(laboratoryReader, configuration))
            using (var demandCsv = new CsvReader(demandReader, configuration))
            {
                demandCsv.Context.RegisterClassMap<DemandMap>();
                laboratoryCsv.Context.RegisterClassMap<LaboratoryMap>();

                var demands = demandCsv.GetRecords<Demand>().ToList();
                var laboratories = laboratoryCsv.GetRecords<Laboratory>().ToList();

                foreach (var intelligence in intelligences)
                {
                    foreach (var demand in demands)
                    {
                        foreach (var laboratory in laboratories)
                        {
                            var record = tests.FirstOrDefault(x => x.Demand == demand.Id && x.Laboratory == laboratory.Id && x.Intelligence == intelligence);

                            if (record is null)
                            {
                                var (status, time, keywords) = await Extract(laboratory, intelligence);

                                await testsRepository.InsertAsync(new Tests
                                {
                                    Time = time,
                                    Status = status,
                                    Demand = demand.Id,
                                    Laboratory = laboratory.Id,
                                    Intelligence = intelligence,
                                    Score = await Analyse(demand, laboratory, keywords),
                                    KeywordCount = laboratory.Keywords.Count,
                                    WordCount = GetWordCount($"{demand.Title}. {demand.Description}. {demand.Details}")
                                });
                            }
                            else if (!record.Status)
                            {
                                var (status, time, keywords) = await Extract(laboratory, intelligence);

                                if (status)
                                {
                                    record.Score = await Analyse(demand, laboratory, keywords);
                                    record.KeywordCount = laboratory.Keywords.Count;
                                    record.Status = status;
                                    record.Time = time;

                                    await testsRepository.UpdateAsync(record);
                                }
                            }
                        }
                    }
                }
            }
        }

        private int GetWordCount(string text)
        {
            return text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private async Task<(bool, long, IList<Keyword>)> Extract(Laboratory laboratory, string intelligence)
        {
            var status = true;
            var timer = Stopwatch.StartNew();
            IList<Keyword> keywords = new List<Keyword>();

            try
            {
                keywords = await languageClient.Extract(new Description { Text = laboratory.Description }, intelligence);
            }
            catch
            {
                status = false;
            }

            timer.Stop();

            return (status && keywords.Count > 0, timer.ElapsedMilliseconds, keywords);
        }

        private async Task<decimal> Analyse(Demand demand, Laboratory laboratory, IList<Keyword> keywords)
        {
            laboratory.Keywords = laboratory.Keywords
                .Concat(keywords.Select(x => new Keyword { Text = x.Text.ToLower(), Weight = x.Weight }))
                .GroupBy(x => x.Text)
                .Select(x => x.OrderByDescending(k => k.Weight).First())
                .ToList();

            try
            {
                var analysis = await languageClient.Analyze(new Analysis
                {
                    Text = $"{demand.Title}. {demand.Description}. {demand.Details}",
                    Laboratories = [laboratory]
                });

                return analysis.First(x => x.Id == laboratory.Id).Score;
            }
            catch
            {
                return 0;
            }
        }
    }
}
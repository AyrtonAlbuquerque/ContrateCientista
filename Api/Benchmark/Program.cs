using System.Globalization;
using Benchmark.Benchmarks;
using Benchmark.Clients;
using Benchmark.Clients.Handlers;
using Benchmark.Domain.Data;
using Benchmark.Domain.Repository;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Scrutor;

namespace Benchmark
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var csvConfiguration = new CsvConfiguration(CultureInfo.InstalledUICulture)
            {
                Delimiter = ","
            };
            var url = configuration["LanguageApi:Url"];

            // Add Configuration
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<CsvConfiguration>(csvConfiguration);
            services.AddMemoryCache();

            // Add Database
            services.AddDbContext<Context>(options => options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies());

            // Add Clients
            services.AddHttpClient<LanguageHandler>(client =>
            {
                client.BaseAddress = new Uri(url);
            });
            services.AddRefitClient<ILanguageClient>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri(url); })
                .AddHttpMessageHandler<LanguageHandler>();

            // Add Repositories
            services.Scan(scan => scan
                .FromAssemblyOf<TestsRepository>()
                .AddClasses(classes => classes.InExactNamespaces("Benchmark.Domain.Repository"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            // Add Benchmarks
            services.Scan(scan => scan
                .FromAssemblyOf<LanguageBenchmark>()
                .AddClasses(classes => classes.InExactNamespaces("Benchmark.Benchmarks"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithScopedLifetime());

            // Build services
            var provider = services.BuildServiceProvider();

            // Run benchmarks
            await provider.GetRequiredService<LanguageBenchmark>().Run();
        }
    }
}
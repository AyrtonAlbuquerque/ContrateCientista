using System.Threading.Tasks;
using Benchmark.Benchmarks;
using Benchmark.Clients;
using Benchmark.Clients.Handlers;
using Benchmark.Domain.Data;
using Benchmark.Domain.Repository;
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
            var url = configuration["Api:Url"];

            // Add Configuration
            services.AddSingleton(configuration);

            // Add Database
            services.AddDbContext<Context>(options => options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies());

            // Add Laboratory Client
            services.AddHttpClient<LaboratoryHandler>(client =>
            {
                client.BaseAddress = new Uri(url);
            });
            services.AddRefitClient<ILaboratoryClient>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri(url); })
                .AddHttpMessageHandler<LaboratoryHandler>();

            // Add Demand Client
            services.AddHttpClient<DemandHandler>(client =>
            {
                client.BaseAddress = new Uri(url);
            });
            services.AddRefitClient<IDemandClient>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri(url); })
                .AddHttpMessageHandler<DemandHandler>();

            // Add Repositories
            services.Scan(scan => scan
                .FromAssemblyOf<TestsRepository>()
                .AddClasses(classes => classes.InExactNamespaces("Benchmark.Domain.Repository"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            // Add Benchmarks
            services.Scan(scan => scan
                .FromAssemblyOf<LaboratoryBenchmark>()
                .AddClasses(classes => classes.InExactNamespaces("Benchmark.Benchmarks"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsSelf()
                .WithScopedLifetime());

            // Build services
            services.BuildServiceProvider();

            // Run benchmarks
            // await services.GetRequiredService<LaboratoryBenchmark>().Run();
            // await services.GetRequiredService<DemandBenchmark>().Run();
        }
    }
}
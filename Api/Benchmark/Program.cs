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
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            // Add Database
            services.AddDbContext<Context>(options => options
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .UseLazyLoadingProxies());

            // Add API
            // services.AddHttpClient<LanguageHandler>(client =>
            // {
            //     client.BaseAddress = new Uri(url);
            // });
            // services.AddRefitClient<ILanguageService>()
            //     .ConfigureHttpClient(c => { c.BaseAddress = new Uri(url); })
            //     .AddHttpMessageHandler<LanguageHandler>();

            // Add Repositories
            services.Scan(scan => scan
                .FromAssemblyOf<TestsRepository>()
                .AddClasses(classes => classes.InExactNamespaces("Benchmark.Domain.Repository"))
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            // Build services
            services.BuildServiceProvider();

            // Run benchmark method

        }
    }
}
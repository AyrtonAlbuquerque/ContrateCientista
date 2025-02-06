using Microsoft.Extensions.Configuration;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var connection = builder.GetConnectionString("DefaultConnection");
        }
    }
}
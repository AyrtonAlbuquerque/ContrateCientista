using Benchmark.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Benchmark.Domain.Data
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Tests> Tests => Set<Tests>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Tests).Assembly);
        }
    }
}
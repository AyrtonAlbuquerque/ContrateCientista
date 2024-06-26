using Api.Domain.Map;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Laboratory> Laboratory => Set<Laboratory>();
        public DbSet<Address> Address => Set<Address>();
        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Person> Person => Set<Person>();
        public DbSet<Software> Software => Set<Software>();
        public DbSet<SocialMedia> SocialMedia => Set<SocialMedia>();
        public DbSet<Company> Company => Set<Company>();
        public DbSet<Demand> Demand => Set<Demand>();
        public DbSet<Match> Match => Set<Match>();
        public DbSet<User> User => Set<User>();
        public DbSet<Keyword> Keyword => Set<Keyword>();
        public DbSet<Status> Status => Set<Status>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AddressMap).Assembly);
        }
    }
}
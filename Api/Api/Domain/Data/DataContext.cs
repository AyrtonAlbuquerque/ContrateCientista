using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Domain.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        // Tables
        public DbSet<Laboratory> Laboratory => Set<Laboratory>();
        public DbSet<Address> Address => Set<Address>();
        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Person> Person => Set<Person>();
        public DbSet<Software> Software => Set<Software>();
        public DbSet<SocialMedia> SocialMedia => Set<SocialMedia>();
    }
}
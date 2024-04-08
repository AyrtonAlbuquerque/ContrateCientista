using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class PersonMap : BaseMap<Person>
    {
        protected override void Configure(EntityTypeBuilder<Person> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).HasMaxLength(255);
            builder.Property(x => x.Department).HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255);
            builder.Property(x => x.Phone).HasMaxLength(20);

            // Indexes
            builder.HasIndex(x => new { x.Email, x.Phone }).IsUnique();
        }
    }
}
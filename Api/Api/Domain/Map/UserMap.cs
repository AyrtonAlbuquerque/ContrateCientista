using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class UserMap : BaseMap<User>
    {
        protected override void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);

            // Relationships
            builder.HasOne(x => x.Company)
                .WithMany()
                .HasForeignKey("CompanyId");

            builder.HasOne(x => x.Laboratory)
                .WithMany()
                .HasForeignKey("LaboratoryId");

            // Indexes
            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => new { x.Email, x.Password });
        }
    }
}
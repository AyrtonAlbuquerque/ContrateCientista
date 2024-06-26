using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class DemandMap : BaseMap<Demand>
    {
        protected override void Configure(EntityTypeBuilder<Demand> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Department).HasMaxLength(255);
            builder.Property(x => x.Benefits).HasMaxLength(1000);
            builder.Property(x => x.Details);
            builder.Property(x => x.Restrictions).HasMaxLength(1000);

            // Relationships
            builder.Navigation(x => x.Matches).AutoInclude();
            builder.Navigation(x => x.Keywords).AutoInclude();
            builder.Navigation(x => x.Company).AutoInclude();
            builder.Navigation(x => x.Responsible).AutoInclude();
            builder.Navigation(x => x.Status).AutoInclude();

            builder.HasOne(x => x.Company)
                .WithMany(c => c.Demands)
                .HasForeignKey("CompanyId")
                .IsRequired();

            builder.HasOne(x => x.Responsible)
                .WithMany()
                .HasForeignKey("ResponsibleId")
                .IsRequired();

            builder.HasOne(x => x.Status)
                .WithMany()
                .HasForeignKey("StatusId")
                .IsRequired();
        }
    }
}
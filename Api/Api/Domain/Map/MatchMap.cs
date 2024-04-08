using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class MatchMap : BaseMap<Match>
    {
        protected override void Configure(EntityTypeBuilder<Match> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Score).IsRequired();

            // Relationships
            builder.Navigation(x => x.Laboratory);
            builder.Navigation(x => x.Demand);
            builder.Navigation(x => x.Status);

            builder.HasOne(x => x.Laboratory)
                .WithMany(l => l.Matches)
                .HasForeignKey("LaboratoryId")
                .IsRequired();

            builder.HasOne(x => x.Demand)
                .WithMany(d => d.Matches)
                .HasForeignKey("DemandId")
                .IsRequired();

            builder.HasOne(x => x.Status)
                .WithMany()
                .HasForeignKey("StatusId")
                .IsRequired();
        }
    }
}
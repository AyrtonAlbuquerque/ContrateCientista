using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class KeywordMap : BaseMap<Keyword>
    {
        protected override void Configure(EntityTypeBuilder<Keyword> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Text).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Weight).IsRequired();

            // Relationships
            builder.HasOne(x => x.Demand)
                .WithMany(d => d.Keywords)
                .HasForeignKey("DemandId");

            builder.HasOne(x => x.Laboratory)
                .WithMany(l => l.Keywords)
                .HasForeignKey("LaboratoryId");
        }
    }
}
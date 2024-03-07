using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class EquipmentMap : BaseMap<Equipment>
    {
        protected override void Configure(EntityTypeBuilder<Equipment> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description);
            builder.Property(x => x.Area).HasMaxLength(255);

            // Relationships
            builder.HasOne(x => x.Laboratory)
                .WithMany(l => l.Equipments)
                .HasForeignKey("LaboratoryId")
                .IsRequired();
        }
    }
}
using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class LaboratoryMap : BaseMap<Laboratory>
    {
        protected override void Configure(EntityTypeBuilder<Laboratory> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Code).HasMaxLength(255);
            builder.Property(x => x.Description);
            builder.Property(x => x.Certificates).HasMaxLength(255);
            builder.Property(x => x.FoundationDate).HasMaxLength(10);

            // Relationships
            builder.Navigation(x => x.Matches).AutoInclude();
            builder.Navigation(x => x.Softwares).AutoInclude();
            builder.Navigation(x => x.Equipments).AutoInclude();
            builder.Navigation(x => x.SocialMedias).AutoInclude();
            builder.Navigation(x => x.Keywords).AutoInclude();
            builder.Navigation(x => x.Address).AutoInclude();
            builder.Navigation(x => x.Responsible).AutoInclude();

            builder.HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey("AddressId")
                .IsRequired();

            builder.HasOne(x => x.Responsible)
                .WithMany()
                .HasForeignKey("ResponsibleId")
                .IsRequired();
        }
    }
}
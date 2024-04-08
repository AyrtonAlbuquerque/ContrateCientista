using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class SocialMediaMap : BaseMap<SocialMedia>
    {
        protected override void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Type).HasMaxLength(255);
            builder.Property(x => x.Link).IsRequired().HasMaxLength(512);

            // Relationships
            builder.Navigation(x => x.Laboratory);

            builder.HasOne(x => x.Laboratory)
                .WithMany(l => l.SocialMedias)
                .HasForeignKey("LaboratoryId")
                .IsRequired();
        }
    }
}
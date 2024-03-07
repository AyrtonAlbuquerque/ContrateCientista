using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class AddressMap : BaseMap<Address>
    {
        protected override void Configure(EntityTypeBuilder<Address> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Street).HasMaxLength(255);
            builder.Property(x => x.Number);
            builder.Property(x => x.Neighborhood).HasMaxLength(255);
            builder.Property(x => x.City).HasMaxLength(255);
            builder.Property(x => x.State).HasMaxLength(255);
            builder.Property(x => x.Country).HasMaxLength(255);
            builder.Property(x => x.Extra).HasMaxLength(255);
        }
    }
}
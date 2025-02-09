using Api.Domain.Map.Base;
using Api.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Domain.Map
{
    public class TestsMap : BaseMap<Tests>
    {
        protected override void Configure(EntityTypeBuilder<Tests> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Laboratory).IsRequired();
            builder.Property(x => x.Demand).IsRequired();
            builder.Property(x => x.Intelligence).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Score).IsRequired();
            builder.Property(x => x.Time).IsRequired();
            builder.Property(x => x.WordCount).IsRequired();
            builder.Property(x => x.KeywordCount).IsRequired();
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
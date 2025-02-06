using Benchmark.Domain.Map.Base;
using Benchmark.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benchmark.Domain.Map
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
        }
    }
}
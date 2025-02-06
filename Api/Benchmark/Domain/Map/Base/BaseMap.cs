using Benchmark.Domain.Model.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Benchmark.Domain.Map.Base
{
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseTable
    {
        protected abstract void Configure(EntityTypeBuilder<T> builder);

        void IEntityTypeConfiguration<T>.Configure(EntityTypeBuilder<T> builder)
        {
            Configure(builder);
        }
    }
}
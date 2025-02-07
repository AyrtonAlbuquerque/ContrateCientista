using Benchmark.Domain.Model.Base;

namespace Benchmark.Domain.Model
{
    public class Tests : BaseTable
    {
        public virtual int Id { get; protected set; }
        public virtual int Laboratory { get; set; }
        public virtual int Demand { get; set; }
        public virtual string Intelligence { get; set; }
        public virtual decimal Score { get; set; }
        public virtual long Time { get; set; }
    }
}
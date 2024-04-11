using Api.Domain.Model.Base;

namespace Api.Domain.Model
{
    public class Match : BaseTable
    {
        public virtual int Id { get; protected set; }
        public virtual Demand Demand { get; set; }
        public virtual Laboratory Laboratory { get; set; }
        public virtual decimal Score { get; set; }
        public virtual bool? Liked { get; set; }
    }
}
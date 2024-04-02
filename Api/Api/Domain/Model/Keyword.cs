using Api.Domain.Model.Base;

namespace Api.Domain.Model
{
    public class Keyword : BaseTable
    {
        public virtual int Id { get; protected set; }
        public virtual string Text { get; set; }
        public virtual decimal Weight { get; set; }
        public virtual Demand Demand { get; set; }
        public virtual Laboratory Laboratory { get; set; }
    }
}
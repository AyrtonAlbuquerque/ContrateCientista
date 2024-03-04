using Api.Domain.Model.Base;

namespace Api.Domain.Model
{
    public class Equipment : BaseTable
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Area { get; set; }
        public virtual Laboratory Laboratory { get; set; }
    }
}
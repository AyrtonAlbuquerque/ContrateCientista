using Api.Domain.Model.Base;

namespace Api.Domain.Model
{
    public class Status : BaseTable
    {
        public virtual int Id { get; init; }
        public virtual string Description { get; set; }
    }
}
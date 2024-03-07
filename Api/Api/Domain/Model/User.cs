using Api.Domain.Model.Base;

namespace Api.Domain.Model
{
    public class User : BaseTable
    {
        public virtual int Id { get; protected set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual Company Company { get; set; }
        public virtual Laboratory Laboratory { get; set; }
    }
}
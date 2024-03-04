using Api.Domain.Model.Base;

namespace Api.Domain.Model
{
    public class SocialMedia : BaseTable
    {
        public virtual int Id { get; protected set; }
        public virtual string Type { get; set; }
        public virtual string Link { get; set; }
        public virtual Laboratory Laboratory { get; set; }
    }
}
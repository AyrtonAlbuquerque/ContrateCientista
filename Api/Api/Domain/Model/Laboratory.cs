using Api.Domain.Model.Base;

namespace Api.Domain.Model
{
    public class Laboratory : BaseTable
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual Person Responsible { get; set; }
        public virtual Address Address { get; set; }
        public virtual string Description { get; set; }
        public virtual string Certificates { get; set; }
        public virtual string FoundationDate { get; set; }
        public virtual IEnumerable<Software> Softwares { get; set; }
        public virtual IEnumerable<Equipment> Equipments { get; set; }
        public virtual IEnumerable<SocialMedia> SocialMedias { get; set; }
        public virtual IEnumerable<Match> Matches { get; set; }
    }
}

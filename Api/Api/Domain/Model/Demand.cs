namespace Api.Domain.Model
{
    public class Demand
    {
        public virtual int Id { get; protected set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual Company Company { get; set; }
        public virtual string Department { get; set; }
        public virtual string Benefits { get; set; }
        public virtual string Details { get; set; }
        public virtual string Restrictions { get; set; }
        public virtual string Keywords { get; set; }
        public virtual Person Responsible { get; set; }
    }
}
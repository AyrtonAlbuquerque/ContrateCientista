namespace Api.Domain.Model
{
    public class Equipment
    {
        public virtual string Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Area { get; set; }
        public virtual Laboratory Laboratory { get; set; }
    }
}
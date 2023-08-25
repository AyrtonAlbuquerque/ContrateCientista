namespace Api.Domain.Model
{
    public class Address
    {
        public virtual int Id { get; protected set; }
        public virtual string Street { get; set; }
        public virtual string Number { get; set; }
        public virtual string Neighborhood { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Country { get; set; }
        public virtual string Extra { get; set; }
    }
}
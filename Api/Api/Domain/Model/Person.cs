namespace Api.Domain.Model
{
    public class Person
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Department { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
    }
}
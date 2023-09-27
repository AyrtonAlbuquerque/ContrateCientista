namespace Api.Domain.Model
{
    public class Company
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string Description { get; set; }
    }
}
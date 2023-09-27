namespace Api.Domain.Model
{
    public class Match
    {
        public virtual int Id { get; protected set; }
        public virtual Demand Demand { get; set; }
        public virtual Laboratory Laboratory { get; set; }
        public virtual string Score { get; set; }
        public virtual int Status { get; set; }
    }
}
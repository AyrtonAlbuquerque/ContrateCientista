namespace Api.Domain.Model
{
    public class SocialMedia
    {
        public virtual string Id { get; protected set; }
        public virtual string Type { get; set; }
        public virtual string Link { get; set; }
        public virtual Laboratory Laboratory { get; set; }
    }
}
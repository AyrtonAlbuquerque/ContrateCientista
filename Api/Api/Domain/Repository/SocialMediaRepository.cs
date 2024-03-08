using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface ISocialMediaRepository : IRepository<SocialMedia>
    {
    }

    public class SocialMediaRepository(DataContext context) : Repository<SocialMedia>(context), ISocialMediaRepository
    {
    }
}
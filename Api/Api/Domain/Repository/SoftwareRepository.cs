using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface ISoftwareRepository : IRepository<Software>
    {
    }

    public class SoftwareRepository : Repository<Software>, ISoftwareRepository
    {
        public SoftwareRepository(DataContext context) : base(context)
        {
        }
    }
}
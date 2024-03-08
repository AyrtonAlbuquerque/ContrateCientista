using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface ISoftwareRepository : IRepository<Software>
    {
    }

    public class SoftwareRepository(DataContext context) : Repository<Software>(context), ISoftwareRepository
    {
    }
}
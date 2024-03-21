using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IStatusRepository : IRepository<Status>
    {
    }

    public class StatusRepository(DataContext context) : Repository<Status>(context), IStatusRepository
    {
    }
}
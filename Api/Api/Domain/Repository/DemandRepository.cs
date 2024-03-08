using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IDemandRepository : IRepository<Demand>
    {
    }

    public class DemandRepository(DataContext context) : Repository<Demand>(context), IDemandRepository
    {
    }
}
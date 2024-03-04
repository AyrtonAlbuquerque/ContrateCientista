using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IDemandRepository : IRepository<Demand>
    {
    }

    public class DemandRepository : Repository<Demand>, IDemandRepository
    {
        public DemandRepository(DataContext context) : base(context)
        {
        }
    }
}
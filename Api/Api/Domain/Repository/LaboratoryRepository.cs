using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface ILaboratoryRepository : IRepository<Laboratory>
    {
    }

    public class LaboratoryRepository : Repository<Laboratory>, ILaboratoryRepository
    {
        public LaboratoryRepository(DataContext context) : base(context)
        {
        }
    }
}
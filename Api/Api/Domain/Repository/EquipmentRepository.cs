using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
    }

    public class EquipmentRepository : Repository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(DataContext context) : base(context)
        {
        }
    }
}
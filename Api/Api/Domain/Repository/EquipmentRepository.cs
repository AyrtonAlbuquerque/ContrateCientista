using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IEquipmentRepository : IRepository<Equipment>
    {
    }

    public class EquipmentRepository(DataContext context) : Repository<Equipment>(context), IEquipmentRepository
    {
    }
}
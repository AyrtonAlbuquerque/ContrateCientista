using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IAddressRepository : IRepository<Address>
    {
    }

    public class AddressRepository(DataContext context) : Repository<Address>(context), IAddressRepository
    {
    }
}
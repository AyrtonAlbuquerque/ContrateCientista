using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IPersonRepository :IRepository<Person>
    {
    }

    public class PersonRepository(DataContext context) : Repository<Person>(context), IPersonRepository
    {
    }
}
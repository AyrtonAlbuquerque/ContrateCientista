using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetAsync(string email, string phone);
    }

    public class PersonRepository(DataContext context) : Repository<Person>(context), IPersonRepository
    {
        public async Task<Person> GetAsync(string email, string phone)
        {
            return await GetAsync(q => q
                .Where(p => p.Email == email && p.Phone == phone));
        }
    }
}
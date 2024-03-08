using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync(string email, string password);
    }

    public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository
    {
        public async Task<User> GetAsync(string email, string password)
        {
            return await GetAsync(q => q
                .Where(u => u.Email == email && u.Password == password));
        }
    }
}
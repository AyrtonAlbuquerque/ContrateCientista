using Api.Domain.Data;
using Api.Domain.Model;
using Api.Domain.Repository.Base;

namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync(string email, string password);

        Task<bool> ExistsAsync(string email);
    }

    public class UserRepository(DataContext context) : Repository<User>(context), IUserRepository
    {
        public async Task<User> GetAsync(string email, string password)
        {
            return await GetAsync(q => q
                .Where(u => u.Email == email && u.Password == password));
        }

        public async Task<bool> ExistsAsync(string email)
        {
            return await ExistsAsync(q => q
                .Where(u => u.Email == email));
        }
    }
}
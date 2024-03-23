using Api.Domain.Model;

namespace Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync();
    }
}
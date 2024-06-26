using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;

namespace Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(Login login);
    }
}
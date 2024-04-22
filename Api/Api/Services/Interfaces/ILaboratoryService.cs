using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;

namespace Api.Services.Interfaces
{
    public interface ILaboratoryService
    {
        Task<LoginResponse> Register(RegisterLaboratory laboratory);
    }
}
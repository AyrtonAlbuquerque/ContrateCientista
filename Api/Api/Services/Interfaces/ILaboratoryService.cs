using Api.Contracts.Auth.Response;
using Api.Contracts.Common;

namespace Api.Services.Interfaces
{
    public interface ILaboratoryService
    {
        Task<Laboratory> Get();
        Task<LoginResponse> Register(Laboratory laboratory);
        Task<Laboratory> Update(Laboratory laboratory);
    }
}
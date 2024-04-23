using Api.Contracts.Auth.Response;
using Api.Contracts.Common;

namespace Api.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> Get();
        Task<LoginResponse> Register(Company company);
        Task<Company> Update(Company company);
    }
}
using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Contracts.Common;

namespace Api.Services.Interfaces
{
    public interface ICompanyService
    {
        Task<LoginResponse> Register(RegisterCompany company);
        Task<Company> Update(Company company);
    }
}
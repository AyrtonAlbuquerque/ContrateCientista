using Api.Contracts.Common;
using Api.Domain.Model;

namespace Api.Services.Interfaces
{
    public interface ITokenService
    {
        Token Create(User user);
    }
}
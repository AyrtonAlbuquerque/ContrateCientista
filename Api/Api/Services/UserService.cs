using Api.Domain.Model;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using System.Security.Claims;

namespace Api.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserRepository userRepository;

        public UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userRepository = userRepository;
        }

        public async Task<User> GetUserAsync()
        {
            return await userRepository.GetAsync(int.Parse(httpContextAccessor.HttpContext?.User?.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value ??
                throw new BadRequestException("Usuário não autenticado.")));
        }
    }
}
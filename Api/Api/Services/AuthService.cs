using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using Api.Utilities;
using Mapster;

namespace Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            this.userRepository = userRepository;
            this.tokenService = tokenService;
        }

        public async Task<LoginResponse> Login(Login login)
        {
            var user = await userRepository.GetAsync(login.Email, ValidationHelper.HashPassword(login.Password)) ?? throw new BadRequestException("Usuário ou Senha Inválidos.");
            var token = tokenService.Create(user);

            return (user, token).Adapt<LoginResponse>();
        }
    }
}
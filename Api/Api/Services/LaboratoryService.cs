using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Contracts.LanguageApi;
using Api.Domain.Model;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using Api.Utilities;
using Mapster;

namespace Api.Services
{
    public class LaboratoryService : ILaboratoryService
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenService tokenService;
        private readonly ILanguageService languageService;

        public LaboratoryService(IUserRepository userRepository, ITokenService tokenService, ILanguageService languageService)
        {
            this.userRepository = userRepository;
            this.tokenService = tokenService;
            this.languageService = languageService;
        }

        public async Task<LoginResponse> Register(RegisterLaboratory laboratory)
        {
            BadRequestException.ThrowIf(await userRepository.ExistsAsync(laboratory.Responsible.Email), "E-mail já cadastrado.");
            BadRequestException.ThrowIf(!ValidationHelper.ValidatePassword(laboratory.Responsible.Password), "Senha inválida. A senha deve conter pelo menos 8 caracteres, uma letra e um número.");

            var keywords = await languageService.Extract(new Description { Text = laboratory.Description });
            var user = await userRepository.InsertAsync((keywords, laboratory).Adapt<User>());
            var token = tokenService.Create(user);

            return (user, token).Adapt<LoginResponse>();
        }
    }
}
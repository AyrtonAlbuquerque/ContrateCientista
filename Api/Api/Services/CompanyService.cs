using Api.Contracts.Auth.Response;
using Api.Domain.Model;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using Api.Utilities;
using Mapster;
using Company = Api.Contracts.Common.Company;

namespace Api.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUserRepository userRepository;
        private readonly IUserService userService;
        private readonly ITokenService tokenService;

        public CompanyService(IUserRepository userRepository, IUserService userService, ITokenService tokenService)
        {
            this.userRepository = userRepository;
            this.userService = userService;
            this.tokenService = tokenService;
        }

        public async Task<Company> Get()
        {
            var user = await userService.GetUserAsync();

            ForbiddenException.ThrowIfNull(user.Company, "Usuário não corresponde a uma empresa, apenas empresas podem obter seus dados");

            return user.Company.Adapt<Company>();
        }

        public async Task<LoginResponse> Register(Company company)
        {
            BadRequestException.ThrowIf(await userRepository.ExistsAsync(company.Email), "E-mail já cadastrado.");
            BadRequestException.ThrowIf(!ValidationHelper.ValidatePassword(company.Password), "Senha inválida. A senha deve conter pelo menos 8 caracteres, uma letra e um número.");
            BadRequestException.ThrowIf(!ValidationHelper.ValidateCNPJ(company.Cnpj), "CNPJ inválido.");

            var user = await userRepository.InsertAsync(company.Adapt<User>());
            var token = tokenService.Create(user);

            return (user, token).Adapt<LoginResponse>();
        }

        public async Task<Company> Update(Company company)
        {
            var user = await userService.GetUserAsync();

            ForbiddenException.ThrowIfNull(user.Company, "Usuário não corresponde a uma empresa, apenas empresas podem atualizar seus dados");
            BadRequestException.ThrowIf(!string.IsNullOrEmpty(company.Cnpj) && !ValidationHelper.ValidateCNPJ(company.Cnpj), "CNPJ inválido.");

            user.Company.Name = company.Name ?? user.Company.Name;
            user.Company.Email = company.Email ?? user.Company.Email;
            user.Company.Cnpj = ValidationHelper.FormatCNPJ(company.Cnpj) ?? user.Company.Cnpj;
            user.Company.Description = company.Description ?? user.Company.Description;

            await userRepository.UpdateAsync(user);

            return user.Company.Adapt<Company>();
        }
    }
}
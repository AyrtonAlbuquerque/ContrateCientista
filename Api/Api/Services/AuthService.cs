using Microsoft.IdentityModel.Tokens;
using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Domain.Model;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using Api.Utilities;
using Mapster;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly string secret;
        private readonly double sessionTime;
        private readonly IUserRepository userRepository;

        public AuthService(IConfiguration configuration, IUserRepository userRepository)
        {
            this.secret = configuration["AppSettings:Secret"];
            this.userRepository = userRepository;

            ArgumentException.ThrowIfNullOrEmpty(secret);

            if (!double.TryParse(configuration["AppSettings:SessionTime"], out sessionTime))
                sessionTime = 1;
        }

        public async Task<LoginResponse> Login(Login login)
        {
            var user = await userRepository.GetAsync(login.Email, ValidationHelper.HashPassword(login.Password)) ?? throw new BadRequestException("Usuário ou Senha Inválidos.");

            return new LoginResponse
            {
                Id = user.Id,
                Type = "Bearer",
                Token = GenerateToken(user),
                Expires = (DateTime.UtcNow.AddHours(sessionTime) - DateTime.UtcNow).TotalMilliseconds
            };
        }

        public async Task<LoginResponse> Register(RegisterCompany company)
        {
            if (await userRepository.ExistsAsync(company.Email)) BadRequestException.Throw("E-mail já cadastrado.");
            if (!ValidationHelper.ValidatePassword(company.Password)) BadRequestException.Throw("Senha inválida. A senha deve conter pelo menos 8 caracteres, uma letra e um número.");
            if (!ValidationHelper.ValidateCNPJ(company.Cnpj)) BadRequestException.Throw("CNPJ inválido.");

            var user = await userRepository.InsertAsync(company.Adapt<User>());

            return new LoginResponse
            {
                Id = user.Id,
                Type = "Bearer",
                Token = GenerateToken(user),
                Expires = (DateTime.UtcNow.AddHours(sessionTime) - DateTime.UtcNow).TotalMilliseconds
            };
        }

        public async Task<LoginResponse> Register(RegisterLaboratory laboratory)
        {
            if (await userRepository.ExistsAsync(laboratory.Responsible.Email)) BadRequestException.Throw("E-mail já cadastrado.");
            if (!ValidationHelper.ValidatePassword(laboratory.Responsible.Password)) BadRequestException.Throw("Senha inválida. A senha feve conter pelo menos 8 caracteres, uma letra e um número.");

            var user = await userRepository.InsertAsync(laboratory.Adapt<User>());

            return new LoginResponse
            {
                Id = user.Id,
                Type = "Bearer",
                Token = GenerateToken(user),
                Expires = (DateTime.UtcNow.AddHours(sessionTime) - DateTime.UtcNow).TotalMilliseconds
            };
        }

        #region Private Methods
        private string GenerateToken(User user)
        {
            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                issuer: "UTFPR",
                audience: "DIREC",
                claims: new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                },
                expires: DateTime.UtcNow.AddHours(sessionTime),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha256Signature)
            ));
        }
        #endregion
    }
}
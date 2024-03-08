using Microsoft.IdentityModel.Tokens;
using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Domain.Model;
using Api.Domain.Repository;
using Api.Exceptions;
using Api.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
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
            var user = await userRepository.GetAsync(login.Email, login.Password) ?? throw new BadRequestException("Usuário ou Senha Inválidos.");

            if (user.Password != HashPassword(login.Password)) BadRequestException.Throw("Senha Inválida.");

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
        
        private string HashPassword(string password)
        {
            return BitConverter.ToString(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
        #endregion
    }
}
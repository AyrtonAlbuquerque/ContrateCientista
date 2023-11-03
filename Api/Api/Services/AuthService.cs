using Microsoft.IdentityModel.Tokens;
using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Domain.Data;
using Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly string secret;
        private readonly double sessionTime;
        private readonly DataContext context;
        private readonly IConfiguration configuration;

        public AuthService(IConfiguration configuration, DataContext context)
        {
            this.configuration = configuration;
            this.context = context;
            secret = configuration["AppSettings:Secret"];

            if (string.IsNullOrEmpty(secret))
                throw new ArgumentNullException(nameof(secret));

            if (!double.TryParse(configuration["AppSettings:SessionTime"], out sessionTime))
                sessionTime = 1;
        }

        public async Task<LoginResponse> Login(Login login)
        {
            return new LoginResponse
            {
                Token = GenerateToken(login.Usuario),
                Type = "Bearer",
                Expires = (DateTime.UtcNow.AddHours(sessionTime) - DateTime.UtcNow).TotalMilliseconds
            };
        }

        #region Private Methods
        private string GenerateToken(string id)
        {
            return new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                issuer: "UTFPR",
                audience: "DIREC",
                claims: new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, id),
                },
                expires: DateTime.UtcNow.AddHours(sessionTime),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)), SecurityAlgorithms.HmacSha256Signature)
            ));
        }
        #endregion
    }
}
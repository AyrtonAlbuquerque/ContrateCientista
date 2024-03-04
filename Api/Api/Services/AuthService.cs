using Microsoft.IdentityModel.Tokens;
using Api.Contracts.Auth;
using Api.Contracts.Auth.Response;
using Api.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly string secret;
        private readonly double sessionTime;

        public AuthService(IConfiguration configuration)
        {
            secret = configuration["AppSettings:Secret"];

            ArgumentException.ThrowIfNullOrEmpty(secret);

            if (!double.TryParse(configuration["AppSettings:SessionTime"], out sessionTime))
                sessionTime = 1;
        }

        public async Task<LoginResponse> Login(Login login)
        {
            return new LoginResponse
            {
                Token = GenerateToken(login.Email),
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
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Contracts.Common;
using Api.Domain.Model;
using Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services
{
    public class TokenService : ITokenService
    {
        private readonly string secret;
        private readonly double sessionTime;

        public TokenService(IConfiguration configuration)
        {
            secret = configuration["AppSettings:Secret"];

            ArgumentException.ThrowIfNullOrEmpty(secret);

            if (!double.TryParse(configuration["AppSettings:SessionTime"], out sessionTime))
                sessionTime = 1;
        }

        public Token Create(User user)
        {
            return new Token
            {
                Type = "Bearer",
                Expires = TimeSpan.FromHours(sessionTime).TotalMilliseconds,
                Value = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                    issuer: "UTFPR",
                    audience: "DIREC",
                    claims: new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    },
                    expires: DateTime.UtcNow.AddHours(sessionTime),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        SecurityAlgorithms.HmacSha256Signature)
                ))
            };
        }
    }
}
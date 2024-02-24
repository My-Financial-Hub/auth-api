﻿using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using FinancialHub.Auth.Application.Configurations;

namespace FinancialHub.Auth.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly TokenServiceSettings settings;
        public TokenService(IOptions<TokenServiceSettings> settings)
        {
            this.settings = settings.Value;
        }

        private SigningCredentials Credentials 
        {
            get
            {
                var key = Encoding.ASCII.GetBytes(this.settings.SecurityKey);
                var securityKey = new SymmetricSecurityKey(key);
                return new SigningCredentials(
                    key: securityKey,
                    algorithm: SecurityAlgorithms.HmacSha256Signature
                );
            }
        }

        public TokenModel GenerateToken(UserModel user)
        {
            var expires = DateTime.UtcNow.AddMinutes(this.settings.Expires);
            var handler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = expires,
                Issuer = this.settings.Issuer,
                Audience = this.settings.Audience,
                SigningCredentials = this.Credentials,
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()!),
                        new Claim(JwtRegisteredClaimNames.Name, user.FirstName)
                    }
                ),
            };

            var securityToken = handler.CreateToken(tokenDescriptor);
            var token = handler.WriteToken(securityToken);

            return new TokenModel(token, expires);
        }
    }
}

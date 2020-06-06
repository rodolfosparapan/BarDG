using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BarDG.Api.Configuration
{
    public static class TokenService
    {
        public static string Gerar(string email, AuthSettings authorizationSettings)
        {           
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(new List<Claim>() {
                new Claim(JwtRegisteredClaimNames.Email, email)
            });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authorizationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = authorizationSettings.Issuer,
                Audience = authorizationSettings.ValidAt,
                Expires = DateTime.UtcNow.AddHours(authorizationSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
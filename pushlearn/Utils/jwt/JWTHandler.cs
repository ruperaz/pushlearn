using ApplicationCore.UserClasses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Utils.jwt
{
    public class JWTHandler
    {
        private readonly JWTConfig _config;
        private readonly SigningCredentials _signingCredentials;
        private readonly SymmetricSecurityKey _secretKey;
        public JWTHandler(IOptions<JWTConfig> Options)
        {
            this._config = Options.Value;
            this._secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.SigningKey));
            this._signingCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);
        }
        public string GenerateJSONWebToken(List<Claim> Claims)
        {
          
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.UtcNow.AddMinutes(_config.ExpireMinutes),
                NotBefore = DateTime.UtcNow,
                Audience = _config.ValidAudience,
                Issuer = _config.ValidIssuer,
                SigningCredentials = _signingCredentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

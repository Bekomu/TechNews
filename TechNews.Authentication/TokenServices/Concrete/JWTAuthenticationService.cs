using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechNews.Authentication.Config;
using TechNews.Authentication.TokenServices.Abstract;
using TechNews.DataAccess.EntityFrameWork.Context;

namespace TechNews.Authentication.TokenServices.Concrete
{
    public class JWTAuthenticationService : IJWTAuthenticationService
    {
        private readonly JWTConfig _jwtConfig;

        public JWTAuthenticationService(IOptions<JWTConfig> options)
        {
            _jwtConfig = options.Value;
        }

        public string GenerateToken(IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Sub,user.Email),
                    new Claim(JwtRegisteredClaimNames.Email,user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                }),

                Expires = DateTime.UtcNow.Add(_jwtConfig.ExpiryTimeFrame), // TODO :  new TimeSpan(0,10,0)
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}

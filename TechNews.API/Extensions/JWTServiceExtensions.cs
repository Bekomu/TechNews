using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TechNews.Authentication.Config;
using TechNews.Authentication.TokenServices.Abstract;
using TechNews.Authentication.TokenServices.Concrete;
using TechNews.DataAccess.EntityFrameWork.Context;

namespace TechNews.API.Extensions
{
    public static class JWTServiceExtensions
    {
        public static void AddAuthenticationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTConfig>(configuration.GetSection("JWTConfig"));
            
            var key = Encoding.ASCII.GetBytes(configuration["JWTConfig:Secret"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key), 
                ValidateIssuer = false, 
                ValidateAudience = false, 
                RequireExpirationTime = false, 
                ValidateLifetime = true
            };

            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.Audience = configuration["Application:Audience"]; 
                x.RequireHttpsMetadata = false; 
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddSingleton<IJWTAuthenticationService, JWTAuthenticationService>() ;
        }

        
    }
}

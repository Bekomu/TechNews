using FluentValidation;
using FluentValidation.AspNetCore;

namespace TechNews.API.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddCustomFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining(typeof(IValidator));

            return services;
        }
    }
}

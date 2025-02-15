using e.Commerce.Core.ServiceContracts;
using e.Commerce.Core.Services;
using e.Commerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace e.Commerce.Core
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add core services to the dependency injection container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>

        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            //TO DO: Add services to the IoC container
            //Core services often include data access, caching and other low-level components.

            services.AddTransient<IUsersService, UsersService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

            return services;
        }
    }
}

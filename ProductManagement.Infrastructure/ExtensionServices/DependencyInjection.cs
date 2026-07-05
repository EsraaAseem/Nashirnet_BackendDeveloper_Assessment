
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.Abstractions.IInterfaces.IExternalServices;
using ProductManagement.Application.Models.Common;
using ProductManagement.Infrastructure.AuthServices;
namespace ProductManagement.Infrastructure.ExtensionServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // JWT
            services.Configure<JWTSettings>(configuration.GetSection("JwtSettings"));
            services.AddScoped<IJwtService, JwtService>();

            // Password
            services.AddScoped<IPasswordHashService, PasswordHashService>();

            return services;
        }
    }
}

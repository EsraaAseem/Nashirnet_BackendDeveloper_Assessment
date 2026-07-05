
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Application.IServices;
using ProductManagement.Application.IServices.IHelpServices;
using ProductManagement.Application.Services;
using ProductManagement.Application.Services.HelpServices;
using ProductManagement.Application.Validators;

namespace ProductManagement.Application.ExtensionServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
            return services;
        }
    }
}

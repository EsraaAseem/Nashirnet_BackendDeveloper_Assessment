
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ProductManagement.Application.IServices.IHelpServices;

namespace ProductManagement.Application.Services.HelpServices
{
    public class CurrentUserService:ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Role
            => _httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;

    }
}

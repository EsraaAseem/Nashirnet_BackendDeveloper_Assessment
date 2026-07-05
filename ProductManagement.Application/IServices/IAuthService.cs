using System;

using ProductManagement.Application.Models.AuthModels;
using ProductManagement.Application.Models.Common;

namespace ProductManagement.Application.IServices
{
    public interface IAuthService
    {
        Task<GenericResponse<string>> RegisterAsync(RegisterRequest request);
        Task<GenericResponse<AuthResponse>> LoginAsync(LoginRequest request);
        Task<GenericResponse<List<RoleDto>>> GetAllRoles();
    }
}

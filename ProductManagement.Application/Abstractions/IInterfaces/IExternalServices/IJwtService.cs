

namespace ProductManagement.Application.Abstractions.IInterfaces.IExternalServices
{
    public interface IJwtService
    {
        string GenerateToken(Guid id, string email, string role);
    }
}

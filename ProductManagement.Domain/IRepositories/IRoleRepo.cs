using System;

using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Enums;

namespace ProductManagement.Domain.IRepositories
{
    public interface IRoleRepo
    {
        Task<Role?> GetByNameAsync(string name);
        Task<List<string>> GetAllowedCategoryIdsAsync(int roleId);
        Task<List<ProductColumn>> GetAllowedColumnsAsync(int roleId);
        Task<List<Role>> GetAllRoles();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Enums;
using ProductManagement.Domain.IRepositories;
using ProductManagement.Presistance.Data;

namespace ProductManagement.Presistance.Repositories
{
    public class RoleRepo:IRoleRepo
    {
        private readonly AppDbContext _context;

        public RoleRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Role?> GetByNameAsync(string name) =>
        await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
        public async Task<List<Role>> GetAllRoles() =>
       await _context.Roles.ToListAsync();

        public async Task<List<string>> GetAllowedCategoryIdsAsync(int roleId) =>
            await _context.RoleCategoryPermissions
                .Where(p => p.RoleId == roleId)
                .Select(p => p.CategoryId)
                .ToListAsync();

        public async Task<List<ProductColumn>> GetAllowedColumnsAsync(int roleId) =>
            await _context.RoleColumnPermissions
                .Where(p => p.RoleId == roleId)
                .Select(p => p.Column)
                .ToListAsync();
    }
}

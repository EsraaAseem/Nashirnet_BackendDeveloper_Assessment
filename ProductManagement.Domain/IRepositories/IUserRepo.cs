using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.IRepositories
{
    public interface IUserRepo
    {
        Task<AppUser?> GetByEmailAsync(string email);
        Task AddAsync(AppUser user);
        Task SaveChangesAsync();
    }
}

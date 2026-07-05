
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;
using ProductManagement.Presistance.Data;

namespace ProductManagement.Presistance.Repositories
{
    public class UserRepo:IUserRepo
    {
        private readonly AppDbContext _context;

        public UserRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetByEmailAsync(string email)
            => await _context.Users.Include(u=>u.Role).FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(AppUser user)
            => await _context.Users.AddAsync(user);

        public async Task SaveChangesAsync()
            => await _context.SaveChangesAsync();
    }
}


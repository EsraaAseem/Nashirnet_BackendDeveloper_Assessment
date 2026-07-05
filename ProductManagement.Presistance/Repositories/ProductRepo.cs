
using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.IRepositories;
using ProductManagement.Presistance.Data;

namespace ProductManagement.Presistance.Repositories
{
    public class ProductRepo:IProductRepo
    {
        private readonly AppDbContext _context;

        public ProductRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> GetByCategoryIdsAsync(IEnumerable<string> categoryIds) =>
        await _context.Products.Include(p => p.Category)
                     .Where(p => categoryIds.Contains(p.CategoryId))
                     .ToListAsync();
    }
}

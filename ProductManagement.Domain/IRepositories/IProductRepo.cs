
using ProductManagement.Domain.Entities;

namespace ProductManagement.Domain.IRepositories
{
    public interface IProductRepo
    {
        Task<List<Product>> GetByCategoryIdsAsync(IEnumerable<string> categoryIds);
    }
}

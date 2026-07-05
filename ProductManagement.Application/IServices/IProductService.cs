using System;

using ProductManagement.Application.Models.Common;
using ProductManagement.Application.Models.ProductModels;

namespace ProductManagement.Application.IServices
{
    public interface IProductService
    {
        Task<GenericResponse<List<ProductListItemDto>>> GetProductsForRoleAsync();

    }
}

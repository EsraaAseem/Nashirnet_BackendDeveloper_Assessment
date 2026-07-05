
using ProductManagement.Application.IServices;
using ProductManagement.Application.IServices.IHelpServices;
using ProductManagement.Application.Models.Common;
using ProductManagement.Application.Models.ProductModels;
using ProductManagement.Domain.Enums;
using ProductManagement.Domain.IRepositories;

namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepository;
        private readonly IRoleRepo _roleRepository;
        private readonly ICurrentUserService _currentUserService;
        public ProductService(IProductRepo productRepository, IRoleRepo roleRepository,ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _roleRepository = roleRepository;
            _currentUserService = currentUserService;
        }

        public async Task<GenericResponse<List<ProductListItemDto>>> GetProductsForRoleAsync()
        {
            var roleName = _currentUserService.Role;
            var role = await _roleRepository.GetByNameAsync(roleName);
            if (role == null)
            {
                return GenericResponse<List<ProductListItemDto>>.BadRequestResponse("Role not Exist");
            }
            var roleId = role.Id;    
            var allowedCategoryIds = await _roleRepository.GetAllowedCategoryIdsAsync(roleId);
            var allowedColumns = await _roleRepository.GetAllowedColumnsAsync(roleId);

            var products = await _productRepository.GetByCategoryIdsAsync(allowedCategoryIds);

            var result = products.Select(p => new ProductListItemDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category.Name,
                IconSvg = p.IconSvg,
                Description = allowedColumns.Contains(ProductColumn.Description) ? p.Description : null,
                Size = allowedColumns.Contains(ProductColumn.Size) ? p.Size : null,
                WholesalePrice = allowedColumns.Contains(ProductColumn.WholesalePrice) ? p.WholesalePrice : null,
                SalePrice = allowedColumns.Contains(ProductColumn.SalePrice) ? p.SalePrice : null
            }).ToList();
            return GenericResponse<List<ProductListItemDto>>.SuccessResponseWithData(result);
        }
    }
}

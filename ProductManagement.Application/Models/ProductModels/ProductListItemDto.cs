
namespace ProductManagement.Application.Models.ProductModels
{
    public class ProductListItemDto
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string IconSvg { get; set; } = default!;

        public string? Description { get; set; }
        public string? Size { get; set; }
        public decimal? WholesalePrice { get; set; }
        public decimal? SalePrice { get; set; }
    }
}

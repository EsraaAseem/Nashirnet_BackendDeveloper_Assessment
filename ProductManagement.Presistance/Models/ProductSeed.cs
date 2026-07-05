

namespace ProductManagement.Presistance.Models
{
    public class ProductSeed
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string CategoryId { get; set; } = default!;
        public string Size { get; set; } = default!;
        public decimal WholesalePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string IconSvg { get; set; } = default!;
    }
}



namespace ProductManagement.Domain.Entities
{
    public class Product
    {
        public string Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string CategoryId { get;  set; }
        public Category Category { get;  set; }
        public string Size { get;  set; }
        public decimal WholesalePrice { get;  set; }
        public decimal SalePrice { get;  set; }
        public string IconSvg { get;  set; } 
    }
}

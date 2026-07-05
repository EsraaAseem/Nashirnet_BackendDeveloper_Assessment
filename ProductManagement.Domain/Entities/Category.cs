
namespace ProductManagement.Domain.Entities
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; } 
        public string IconSvg { get; set; } 
        public ICollection<Product> Products { get;  set; }
        public ICollection<RoleCategoryPermission> RolePermissions { get;  set; }

    }
}

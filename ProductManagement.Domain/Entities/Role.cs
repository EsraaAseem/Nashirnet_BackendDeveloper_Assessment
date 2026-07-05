

namespace ProductManagement.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get;  set; } 
        public ICollection<RoleCategoryPermission> ?CategoryPermissions { get;  set; }
        public ICollection<RoleColumnPermission> ?ColumnPermissions { get;  set; }

    }
}

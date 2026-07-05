

namespace ProductManagement.Domain.Entities
{
    public class RoleCategoryPermission
    {
        public int RoleId { get;  set; }
        public Role Role { get;  set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }


    }
}

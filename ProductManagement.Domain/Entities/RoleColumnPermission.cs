
using ProductManagement.Domain.Enums;

namespace ProductManagement.Domain.Entities
{
    public class RoleColumnPermission
    {
        public int RoleId { get;  set; }
        public Role Role { get;  set; } = default!;

        public ProductColumn Column { get;  set; }

       
    }
}

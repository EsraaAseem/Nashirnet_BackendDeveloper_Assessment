

namespace ProductManagement.Domain.Entities
{
    public class AppUser
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get;  set; } = new byte[64];
        public byte[] PasswordSalt { get;  set; } = new byte[64];
        public int RoleId { get;  set; }
        public Role Role { get;  set; } 


    }
}

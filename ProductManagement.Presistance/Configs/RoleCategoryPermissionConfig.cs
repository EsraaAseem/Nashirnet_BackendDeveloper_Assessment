using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Presistance.Configs
{
    public class RoleCategoryPermissionConfig : IEntityTypeConfiguration<RoleCategoryPermission>
    {
        public void Configure(EntityTypeBuilder<RoleCategoryPermission> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.CategoryId });
        }
    }
}
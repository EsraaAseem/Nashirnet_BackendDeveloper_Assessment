using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Presistance.Configs
{
    public class RoleColumnPermissionConfig : IEntityTypeConfiguration<RoleColumnPermission>
    {
        public void Configure(EntityTypeBuilder<RoleColumnPermission> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.Column });

            builder.Property(x => x.Column)
                .IsRequired();
        }
    }
}
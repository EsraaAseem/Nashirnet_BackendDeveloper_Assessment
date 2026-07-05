using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Enums;
using ProductManagement.Presistance.Data;
using ProductManagement.Presistance.Models;

namespace ProductManagement.Presistance.Services
{
    public class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context, string contentRootPath)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            if (!await context.Categories.AnyAsync())
            {
                var categoriesJson = await File.ReadAllTextAsync(
                    Path.Combine(contentRootPath, "SeedData", "categories.json"));
                var categoriesDto = JsonSerializer.Deserialize<List<CategorySeed>>(categoriesJson, jsonOptions)!;

                var categories = categoriesDto.Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    IconSvg = c.IconSvg
                });

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            if (!await context.Products.AnyAsync())
            {
                var productsJson = await File.ReadAllTextAsync(
                    Path.Combine(contentRootPath, "SeedData", "products.json"));
                var productsDto = JsonSerializer.Deserialize<List<ProductSeed>>(productsJson, jsonOptions)!;

                var products = productsDto.Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    CategoryId = p.CategoryId,
                    Size = p.Size,
                    WholesalePrice = p.WholesalePrice,
                    SalePrice = p.SalePrice,
                    IconSvg = p.IconSvg
                });

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

            if (!await context.Roles.AnyAsync())
            {
                var sales = new Role { Name = "Sales" };
                var inventoryManager = new Role { Name = "InventoryManager" };
                var admin = new Role { Name = "Admin" };

                await context.Roles.AddRangeAsync(sales, inventoryManager, admin);
                await context.SaveChangesAsync();

                context.RoleCategoryPermissions.AddRange(
                    new RoleCategoryPermission { RoleId = sales.Id, CategoryId = "CAT-01" },        // Electronics
                    new RoleCategoryPermission { RoleId = sales.Id, CategoryId = "CAT-03" },        // Apparel
                    new RoleCategoryPermission { RoleId = inventoryManager.Id, CategoryId = "CAT-02" }, // Home & Kitchen
                    new RoleCategoryPermission { RoleId = inventoryManager.Id, CategoryId = "CAT-04" }, // Office Supplies

                    new RoleCategoryPermission { RoleId = admin.Id, CategoryId = "CAT-01" },
                    new RoleCategoryPermission { RoleId = admin.Id, CategoryId = "CAT-02" },
                    new RoleCategoryPermission { RoleId = admin.Id, CategoryId = "CAT-03" },
                    new RoleCategoryPermission { RoleId = admin.Id, CategoryId = "CAT-04" }
                );

                context.RoleColumnPermissions.AddRange(
                    new RoleColumnPermission {RoleId= sales.Id,Column= ProductColumn.Description },
                    new RoleColumnPermission { RoleId = sales.Id, Column = ProductColumn.Size },
                    new RoleColumnPermission { RoleId = sales.Id, Column = ProductColumn.SalePrice },

                    new RoleColumnPermission { RoleId = inventoryManager.Id, Column = ProductColumn.Size },
                    new RoleColumnPermission { RoleId = inventoryManager.Id, Column = ProductColumn.WholesalePrice },
                    new RoleColumnPermission { RoleId = admin.Id, Column = ProductColumn.Description },
                    new RoleColumnPermission { RoleId = admin.Id, Column = ProductColumn.Size },
                    new RoleColumnPermission { RoleId = admin.Id, Column = ProductColumn.WholesalePrice },
                    new RoleColumnPermission { RoleId = admin.Id, Column = ProductColumn.SalePrice });

                await context.SaveChangesAsync();
            }
        }
    }
}
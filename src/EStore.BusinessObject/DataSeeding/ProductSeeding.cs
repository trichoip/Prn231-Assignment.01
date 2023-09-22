using EStore.BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.BusinessObject.DataSeeding
{
    public class ProductSeeding : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Candy", Weight = "500g", UnitPrice = 20000, UnitsInStock = 19 },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Mixed Candy", Weight = "300g", UnitPrice = 300000, UnitsInStock = 18 },
                new Product { ProductId = 3, CategoryId = 1, ProductName = "Cake", Weight = "200g", UnitPrice = 15000, UnitsInStock = 40 },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Pepsi", Weight = "250ml", UnitPrice = 10000, UnitsInStock = 45 },
                new Product { ProductId = 5, CategoryId = 1, ProductName = "Snack Oshi's", Weight = "100g", UnitPrice = 15000, UnitsInStock = 31 }
            );
        }
    }
}

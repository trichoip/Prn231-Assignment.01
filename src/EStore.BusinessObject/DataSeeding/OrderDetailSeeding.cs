using EStore.BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.BusinessObject.DataSeeding
{
    public class OrderDetailSeeding : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasData(
                new OrderDetail { OrderId = 1, ProductId = 1, UnitPrice = 20000, Quantity = 1, Discount = 5 },
                new OrderDetail { OrderId = 1, ProductId = 4, UnitPrice = 10000, Quantity = 3, Discount = 10 },
                new OrderDetail { OrderId = 2, ProductId = 5, UnitPrice = 15000, Quantity = 4, Discount = 15 },
                new OrderDetail { OrderId = 2, ProductId = 2, UnitPrice = 300000, Quantity = 2, Discount = 5 },
                new OrderDetail { OrderId = 3, ProductId = 4, UnitPrice = 10000, Quantity = 2, Discount = 5 }
            );
        }
    }
}

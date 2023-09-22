using EStore.BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EStore.BusinessObject.DataSeeding
{
    public class OrderSeeding : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
               new Order
               {
                   OrderId = 4665,
                   Freight = 10000,
                   OrderDate = DateTime.Parse("2021-11-05 12:05:07.677"),
                   RequiredDate = DateTime.Parse("2021-11-04 00:00:00.000"),
                   ShippedDate = DateTime.Parse("2021-11-05 00:00:00.000"),
                   MemberId = 1
               },
               new Order
               {
                   OrderId = 6113,
                   Freight = 20000,
                   OrderDate = DateTime.Parse("2021-11-05 14:04:07.950"),
                   RequiredDate = DateTime.Parse("2021-11-04 00:00:00.000"),
                   ShippedDate = DateTime.Parse("2021-11-05 00:00:00.000"),
                   MemberId = 2
               },
               new Order
               {
                   OrderId = 6259,
                   Freight = 15000,
                   OrderDate = DateTime.Parse("2021-11-05 14:02:50.557"),
                   RequiredDate = DateTime.Parse("2021-11-06 00:00:00.000"),
                   ShippedDate = DateTime.Parse("2021-11-07 00:00:00.000"),
                   MemberId = 1
               },
               new Order
               {
                   OrderId = 4,
                   Freight = 10,
                   OrderDate = DateTime.Now,
                   RequiredDate = DateTime.Now.AddDays(7),
                   ShippedDate = DateTime.Now.AddDays(7),
                   MemberId = 1
               },
               new Order
               {
                   OrderId = 5,
                   Freight = 10,
                   OrderDate = DateTime.Now,
                   RequiredDate = DateTime.Now.AddDays(7),
                   ShippedDate = DateTime.Now.AddDays(7),
                   MemberId = 2
               },
               new Order
               {
                   OrderId = 6,
                   Freight = 10,
                   OrderDate = DateTime.Now,
                   RequiredDate = DateTime.Now.AddDays(7),
                   ShippedDate = DateTime.Now.AddDays(7),
                   MemberId = 2
               },
               new Order
               {
                   OrderId = 7,
                   Freight = 10,
                   OrderDate = DateTime.Now,
                   RequiredDate = DateTime.Now.AddDays(7),
                   ShippedDate = DateTime.Now.AddDays(7),
                   MemberId = 2,
               }
            );
        }
    }
}

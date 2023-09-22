using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EStore.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Drink" }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "MemberId", "City", "CompanyName", "Country", "Email", "Password" },
                values: new object[,]
                {
                    { 1, "HCM", "KMS", "Viet nam", "member1@fstore.com", "1" },
                    { 2, "HCM", "CyberSoft", "Viet nam", "member2@fstore.com", "1" },
                    { 3, "HCM", "CyberSoft", "Viet nam", "1", "1" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Freight", "MemberId", "OrderDate", "RequiredDate", "ShippedDate" },
                values: new object[,]
                {
                    { 4, 10m, 1, new DateTime(2023, 9, 21, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6080), new DateTime(2023, 9, 28, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6089), new DateTime(2023, 9, 28, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6094) },
                    { 5, 10m, 2, new DateTime(2023, 9, 21, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6095), new DateTime(2023, 9, 28, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6096), new DateTime(2023, 9, 28, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6096) },
                    { 6, 10m, 2, new DateTime(2023, 9, 21, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6098), new DateTime(2023, 9, 28, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6098), new DateTime(2023, 9, 28, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6099) },
                    { 7, 10m, 2, new DateTime(2023, 9, 21, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6100), new DateTime(2023, 9, 28, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6101), new DateTime(2023, 9, 28, 19, 2, 12, 670, DateTimeKind.Local).AddTicks(6102) },
                    { 4665, 10000m, 1, new DateTime(2021, 11, 5, 12, 5, 7, 677, DateTimeKind.Unspecified), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6113, 20000m, 2, new DateTime(2021, 11, 5, 14, 4, 7, 950, DateTimeKind.Unspecified), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6259, 15000m, 1, new DateTime(2021, 11, 5, 14, 2, 50, 557, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "ProductName", "UnitPrice", "UnitsInStock", "Weight" },
                values: new object[,]
                {
                    { 1, 1, "Candy", 20000m, 19, "500g" },
                    { 2, 1, "Mixed Candy", 300000m, 18, "300g" },
                    { 3, 1, "Cake", 15000m, 40, "200g" },
                    { 4, 2, "Pepsi", 10000m, 45, "250ml" },
                    { 5, 1, "Snack Oshi's", 15000m, 31, "100g" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "OrderId", "ProductId", "Discount", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 4665, 1, 5.0, 1, 20000m },
                    { 6113, 4, 10.0, 3, 10000m },
                    { 6113, 5, 15.0, 4, 15000m },
                    { 6259, 2, 5.0, 2, 300000m },
                    { 6259, 4, 5.0, 2, 10000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 4665, 1 });

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 6113, 4 });

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 6113, 5 });

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 6259, 2 });

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumns: new[] { "OrderId", "ProductId" },
                keyValues: new object[] { 6259, 4 });

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4665);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6113);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 6259);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Member",
                keyColumn: "MemberId",
                keyValue: 2);
        }
    }
}

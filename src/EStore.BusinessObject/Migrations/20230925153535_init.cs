using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EStore.BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Country = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    Password = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    Weight = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Freight = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, 10000m, 1, new DateTime(2021, 11, 5, 12, 5, 7, 677, DateTimeKind.Unspecified), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 20000m, 2, new DateTime(2021, 11, 5, 14, 4, 7, 950, DateTimeKind.Unspecified), new DateTime(2021, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 15000m, 1, new DateTime(2021, 11, 5, 14, 2, 50, 557, DateTimeKind.Unspecified), new DateTime(2021, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 10m, 1, new DateTime(2023, 9, 25, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2412), new DateTime(2023, 10, 2, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2424), new DateTime(2023, 10, 2, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2428) },
                    { 5, 10m, 2, new DateTime(2023, 9, 25, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2431), new DateTime(2023, 10, 2, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2432), new DateTime(2023, 10, 2, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2433) },
                    { 6, 10m, 2, new DateTime(2023, 9, 25, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2435), new DateTime(2023, 10, 2, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2435), new DateTime(2023, 10, 2, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2436) },
                    { 7, 10m, 2, new DateTime(2023, 9, 25, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2438), new DateTime(2023, 10, 2, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2439), new DateTime(2023, 10, 2, 22, 35, 35, 309, DateTimeKind.Local).AddTicks(2439) }
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
                    { 1, 1, 5.0, 1, 20000m },
                    { 1, 4, 10.0, 3, 10000m },
                    { 2, 2, 5.0, 2, 300000m },
                    { 2, 5, 15.0, 4, 15000m },
                    { 3, 4, 5.0, 2, 10000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_MemberId",
                table: "Order",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

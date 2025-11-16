using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryPattern.Migrations
{
    /// <inheritdoc />
    public partial class addIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "OrderItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic devices and gadgets", "Electronics" },
                    { 2, "Various genres of books and literature", "Books" },
                    { 3, "Men's and women's apparel", "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John Doe" },
                    { 2, "jane@example.com", "Jane Smith" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "High performance laptop", "Laptop", 1500m },
                    { 2, 1, "Latest model smartphone", "Smartphone", 800m },
                    { 3, 2, "Comprehensive guide to ASP.NET Core", "ASP.NET Core Book", 40m }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "OrderId", "CustomerId", "OrderAmount", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, 1540.00m, new DateTime(2024, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 840.00m, new DateTime(2024, 2, 5, 15, 45, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1500.00m },
                    { 2, 1, 3, 1, 40.00m },
                    { 3, 2, 2, 1, 800.00m },
                    { 4, 2, 3, 1, 40.00m }
                });
        }
    }
}

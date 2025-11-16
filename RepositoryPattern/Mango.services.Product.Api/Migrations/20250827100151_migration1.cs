using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.services.ProductApi.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, "Appetizer", "quisque vel lacus", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.cubesnjuliennes.com%2Findian-samosa-recipe-punjabi-samosa%2F&psig=AOvVaw1ZGhHb19e6cBFmdU0XQS3h&ust=1756359375355000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCLCuhNaiqo8DFQAAAAAdAAAAABAE", "Samosa", 120.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}

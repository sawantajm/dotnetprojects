using Mango.services.Product.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.services.ProductApi.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        
        public DbSet<Product1> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product1>().HasData(new Product1
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 120,
                Description = "quisque vel lacus",
                ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.cubesnjuliennes.com%2Findian-samosa-recipe-punjabi-samosa%2F&psig=AOvVaw1ZGhHb19e6cBFmdU0XQS3h&ust=1756359375355000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCLCuhNaiqo8DFQAAAAAdAAAAABAE",
                CategoryName = "Appetizer"

            });
        }
    }
}

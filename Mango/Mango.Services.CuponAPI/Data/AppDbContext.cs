using Mango.Services.CuponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CuponAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cupon> cupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cupon>().HasData(new Cupon
            {
                    
                    CouponId =1,
                    CuponCode="10OFF",
                    Discount= 10,
                    minAmmount=20
            });
            modelBuilder.Entity<Cupon>().HasData(new Cupon
            {

                CouponId = 2,
                CuponCode = "20OFF",
                Discount = 20,
                minAmmount = 40
            });
        }
    }
}

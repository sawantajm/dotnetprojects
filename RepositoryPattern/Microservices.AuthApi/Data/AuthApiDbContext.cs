using Microservices.AuthApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Microservices.AuthApi.Data
{
    public class AuthApiDbContext:IdentityDbContext<ApplicationUser>
    {
        public AuthApiDbContext(DbContextOptions<AuthApiDbContext> options) :base(options)
        {
            
        }
        public DbSet<ApplicationUser> ApplicationUsers {  get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

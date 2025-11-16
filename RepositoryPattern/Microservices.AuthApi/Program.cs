
using Microservices.AuthApi.Data;
using Microservices.AuthApi.Models;
using Microservices.AuthApi.Services;
using Microservices.AuthApi.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;

namespace Microservices.AuthApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AuthApiDbContext>(Options =>
            {
                Options.UseSqlServer(builder.Configuration.GetConnectionString("Con"));
                
            });
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
            builder.Services.AddScoped<IJWTTockenGenerator, JWTTockenGenerator>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AuthApiDbContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
            });
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            ApplyMigration();
            app.Run();
            void ApplyMigration()
            {
                using(var Scope= app.Services.CreateScope())
                {
                    var _db = Scope.ServiceProvider.GetRequiredService<AuthApiDbContext>();
                    if(_db.Database.GetPendingMigrations().Count()>0)
                    {
                        _db.Database.Migrate();
                    }
                }
            }
        }
    }
}

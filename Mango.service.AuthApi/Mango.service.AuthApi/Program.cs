
using Mango.service.AuthApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Mango.service.AuthApi
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

            builder.Services.AddDbContext<AuthDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString(""));
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            void ApplyMigration()
            {
                using (var scop = app.Services.CreateScope())
                {
                    var _db = scop.ServiceProvider.GetRequiredService<AuthDbContext>;
                    if(_db.Database.GetpendingMigrations().count()>0)
                    {
                        _db.Database.Migrate();
                    }
                }
            }
        }
    }
}

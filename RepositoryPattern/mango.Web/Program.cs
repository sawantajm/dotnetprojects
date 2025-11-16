using mango.Web.Services;
using mango.Web.Services.IServices;
using mango.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace mango.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();

            builder.Services.AddHttpClient<IcouponService, CouponService>();
            builder.Services.AddHttpClient<IAuthService, AuthService>();

            SD.CouponApiBase = builder.Configuration["ServiceUrls:CouponUrl"];
            SD.AuthApiBase = builder.Configuration["ServiceUrls:AuthApi"];
            SD.ProductApiBase = builder.Configuration["ServiceUrls:ProductApiUrl"];

            builder.Services.AddScoped<ITockenProvider, TockenProvider>();
            builder.Services.AddScoped<IBaseService, BaseService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IcouponService, CouponService>();
            builder.Services.AddScoped<IProudctService, ProductService>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromHours(10);
                    options.LoginPath = "/auth/Login";
                    options.AccessDeniedPath = "/auth/AccessDenied";

                });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

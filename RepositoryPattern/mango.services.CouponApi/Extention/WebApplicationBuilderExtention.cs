using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace mango.services.CouponApi.Extention
{
    public static class WebApplicationBuilderExtention
    {
        public static WebApplicationBuilder AddAppAuthentication(this WebApplicationBuilder builder)
        {

            var settingsection = builder.Configuration.GetSection("ApiSettings");
            var secret = settingsection.GetValue<string>("secret");
            var ISSUER = settingsection.GetValue<string>("ISSUER");
            var Audience = settingsection.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secret);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = ISSUER,
                    ValidAudience = Audience,
                    ValidateAudience = true,
                };
            }

            );
            return builder;
        }
    }
}

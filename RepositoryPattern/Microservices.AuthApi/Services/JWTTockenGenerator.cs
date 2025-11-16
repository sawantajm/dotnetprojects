using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microservices.AuthApi.Models;
using Microservices.AuthApi.Services.IService;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Microservices.AuthApi.Services
{
    public class JWTTockenGenerator : IJWTTockenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public JWTTockenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
            
        }
        public string GenerateToken(ApplicationUser user, IEnumerable<string> roles)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_jwtOptions.secret);

            var claimList = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName)

            };
            claimList.AddRange(roles.Select(role => new Claim(ClaimTypes.Role,role)));
            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.ISSUER,
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tocken = TokenHandler.CreateToken(TokenDescriptor);

            return TokenHandler.WriteToken(tocken);
        }
    }
}

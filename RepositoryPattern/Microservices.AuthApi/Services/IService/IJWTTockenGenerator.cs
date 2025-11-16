using Microservices.AuthApi.Models;

namespace Microservices.AuthApi.Services.IService
{
    public interface IJWTTockenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser,IEnumerable<string> roles);
    }
}

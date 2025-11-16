using Microsoft.AspNetCore.Identity;

namespace Microservices.AuthApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

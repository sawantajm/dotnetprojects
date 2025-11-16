namespace Microservices.AuthApi.Models
{
    public class JwtOptions
    {
            public string secret { get; set; } = string.Empty;
            public string ISSUER   {get;set;} = string.Empty;
            public string Audience {get;set;} = string.Empty;
    }
}

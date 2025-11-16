namespace Microservices.AuthApi.Models.DTO
{
    public class RegistrationDTO
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Password { get; set; }
        public string? Role { get; set; }

    }
}

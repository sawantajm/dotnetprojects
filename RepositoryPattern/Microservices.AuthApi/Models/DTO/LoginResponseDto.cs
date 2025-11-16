namespace Microservices.AuthApi.Models.DTO
{
    public class LoginResponseDto
    {
        public UserDTO User { get; set; }
        public string Tocken {  get; set; }
    }
}

using Microservices.AuthApi.Models.DTO;

namespace Microservices.AuthApi.Services.IService
{
    public interface IAuthService
    {
        public  Task<string> Register(RegistrationDTO registrationDTO);
        public  Task<LoginResponseDto> Login(LoginRequestDTO loginRequestDTO);

        public Task<bool> AssignRole(string email, string RoleName);

        public Task<ResetPasswordDto?> ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}

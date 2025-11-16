using System.Globalization;
using mango.Web.Models.Dto;
using Microservices.AuthApi.Models.DTO;
using Microsoft.AspNetCore.Identity.Data;

namespace mango.Web.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDTO loginRequest);
        Task<ResponseDto?> RegisterAsync(RegistrationDTO registrationDTO);
        Task<ResponseDto?> AssignRoleAsync(RegistrationDTO registrationDTO);
        public Task<ResponseDto?> ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}

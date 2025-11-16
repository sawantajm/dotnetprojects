
using mango.Web.Models.Dto;
using mango.Web.Models;
using mango.Web.Models.Dto;
using mango.Web.Services.IServices;
using mango.Web.Utility;
using Microservices.AuthApi.Models.DTO;
using Microsoft.AspNetCore.Identity.Data;
namespace mango.Web.Services
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseservice;
        private readonly IAuthService _authservice;
        public AuthService(IBaseService baseService)
        {
                _baseservice = baseService;
        }
        public async Task<ResponseDto?> AssignRoleAsync(RegistrationDTO registrationDTO)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationDTO,
                Url= SD.AuthApiBase + "/api/auth/AssignRole"

            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDTO loginRequest)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequest,
                Url = SD.AuthApiBase + "/api/auth/Login"

            },withBearer:false);
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationDTO registrationDTO)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = registrationDTO,
                Url = SD.AuthApiBase + "/api/auth/register"

            }, withBearer: false);
        }


        

        public async Task<ResponseDto?> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            return await _baseservice.Sendasync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = resetPasswordDto,
                Url = SD.AuthApiBase + "/api/auth/ResetPassword"

            }, withBearer: false);
        }
    }
}

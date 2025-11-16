using Microservices.AuthApi.Models.DTO;
using Microservices.AuthApi.Services.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Microservices.AuthApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    //[Authorize]
    public class AuthApiController : ControllerBase
    {

        private readonly IAuthService _authService;
        private ResponseDTO _responseDTO;

        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
            _responseDTO = new();
        }

        [HttpPost("register")]

        public  async Task<IActionResult> Register([FromBody] RegistrationDTO model)
        {
            var errorMessage = await _authService.Register(model);
            if(!string.IsNullOrEmpty(errorMessage))
            {
                _responseDTO.Issucess = false;
                _responseDTO.Message = errorMessage;
                return BadRequest(_responseDTO);
            }
            return Ok(_responseDTO);
        }
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationDTO model)
        {
            var ToAssignRoleSucessfull = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if(!ToAssignRoleSucessfull)
            {
                _responseDTO.Issucess = false;
                _responseDTO.Message = "Error Occured";
                return BadRequest(_responseDTO);
            }
           
            return Ok(_responseDTO);
        }

        [HttpPost("Login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var IsUserLogin = await _authService.Login(loginRequestDTO);
            if (IsUserLogin.User == null)
            {
                _responseDTO.Issucess = false;
                _responseDTO.Message = "Username Or Password is incorrect";
                return BadRequest(_responseDTO);
            }
            _responseDTO.Result = IsUserLogin;
            return Ok(_responseDTO);
        }

        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var ispasswordreset = await _authService.ResetPassword(resetPasswordDto);

            if(ispasswordreset.NewPassword !=null && ispasswordreset.UserName !=null)
            {
                _responseDTO.Result = ispasswordreset;
                return Ok(_responseDTO);
            }
            _responseDTO.Issucess = false;
            _responseDTO.Message = "Error occured whilw reseting the password..";
            return BadRequest(_responseDTO);
        }
        
    }
}

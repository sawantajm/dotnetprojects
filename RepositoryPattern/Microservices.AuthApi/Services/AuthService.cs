using System.Reflection.Metadata.Ecma335;
using Microservices.AuthApi.Data;
using Microservices.AuthApi.Models;
using Microservices.AuthApi.Models.DTO;
using Microservices.AuthApi.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.AuthApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AuthApiDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly IJWTTockenGenerator _jwtTockenGenerator;
        public AuthService(AuthApiDbContext db , UserManager<ApplicationUser> usermanager,RoleManager<IdentityRole> roleManager ,IJWTTockenGenerator jWTTockenGenerator)
        {
            _dbContext = db;
            _jwtTockenGenerator = jWTTockenGenerator;
            _userManager = usermanager;
            _rolemanager = roleManager;
        }
        public async Task<bool> AssignRole(string Email, string roleName)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == Email.ToLower());
            if(user !=null)
            {
                //create a role if it not exist
                if(!_rolemanager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    _rolemanager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                 await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;
        }
        public async Task<LoginResponseDto> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());
            bool Isvalid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if(user == null || Isvalid ==false)
            {
                return new LoginResponseDto() 
                    {
                    User = null,
                    Tocken =""
                };

            }
            //generate the JWT tocken 
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTockenGenerator.GenerateToken(user, roles);

            UserDTO userdto = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new()
            {
                User = userdto,
                Tocken = token
            };

            return loginResponseDto;
        }

         public async Task<string> Register(RegistrationDTO registrationDTO)
        {
            ApplicationUser user = new()
            {
                UserName = registrationDTO.Email,
                Email = registrationDTO.Email,
                NormalizedEmail = registrationDTO.Email.ToUpper(),
                Name= registrationDTO.Name,
                PhoneNumber =registrationDTO.PhoneNumber,

            };
            try
            {
                var result = await _userManager.CreateAsync(user, registrationDTO.Password);
                if (result.Succeeded)
                {
                    var userReturn = _dbContext.ApplicationUsers.First(u => u.UserName == registrationDTO.Email);
                    UserDTO userDto = new()
                    {
                          Email = userReturn.Email,
                          ID= userReturn.Id,
                          Name = userReturn.Name,
                          PhoneNumber =userReturn.PhoneNumber

                    };

                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception ex)
            {

            }
            return "Error Encountered";


         }
        public async Task<ResetPasswordDto?> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.UserName);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, resetPasswordDto.NewPassword);
            }
            return resetPasswordDto;
        }


    }
}

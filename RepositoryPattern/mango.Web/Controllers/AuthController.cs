using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using mango.Web.Models.Dto;
using mango.Web.Services.IServices;
using mango.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITockenProvider _provider;
        public AuthController(IAuthService authService, ITockenProvider tockenProvider)
        {
                _authService = authService;
                _provider = tockenProvider;
        }
        [HttpGet]
        public  IActionResult Login()
        {
            LoginRequestDTO? loginRequestDTO = new LoginRequestDTO();
            return View(loginRequestDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO login)
        {
            ResponseDto response = await _authService.LoginAsync(login);
           
            if (response.Result != null && response.IsSuccess)
            {
                LoginResponseDto loginResponseDto =  JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(response.Result));
                await signInUser(loginResponseDto);
                _provider.SetTocken(loginResponseDto.Tocken);
                return RedirectToAction("Index", "Home");
            }
           else
            {
             
                    TempData["error"] = response.Message;
               
                return View(login);
            }
         


        }
        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem {Text = SD.RoleAdmin,Value =SD.RoleAdmin},
                new SelectListItem {Text = SD.RoleCutomer,Value =SD.RoleCutomer}
            };
            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register( RegistrationDTO registrationDTO)
        {
            ResponseDto response = await _authService.RegisterAsync(registrationDTO);
            ResponseDto assignrole;
            if (response != null && response.IsSuccess)
            {
                if(string.IsNullOrEmpty(registrationDTO.Role))
                {
                    registrationDTO.Role = SD.RoleAdmin;
                }
                assignrole = await _authService.AssignRoleAsync(registrationDTO);
                if (assignrole != null && assignrole.IsSuccess)
                {
                    TempData["sucsess"] = "Registration sucessfully.. ";
                }
                return RedirectToAction(nameof(Login));
            }
            else
            {
                TempData["error"] = response.Message;
            }
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem {Text = SD.RoleAdmin,Value =SD.RoleAdmin},
                new SelectListItem {Text = SD.RoleCutomer,Value =SD.RoleCutomer}
            };
            ViewBag.RoleList = roleList;
            return View(registrationDTO);

            
        }
        
        public async  Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _provider.ClearTocken();


            return RedirectToAction("Index", "Home");
        }

        private async Task signInUser(LoginResponseDto model)
        {
            var handler = new JwtSecurityTokenHandler();

            if(model!=null)
            {
                var jwt = handler.ReadJwtToken(model.Tocken);
                var Identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                Identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                    jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

                Identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                    jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

                Identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                    jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));

                Identity.AddClaim(new Claim(ClaimTypes.Name,
                   jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));

                Identity.AddClaim(new Claim(ClaimTypes.Role,
                   jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));
                var principal = new ClaimsPrincipal(Identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
         


           
        }
    }
}

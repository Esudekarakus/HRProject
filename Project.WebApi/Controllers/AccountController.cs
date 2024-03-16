using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Services.Abstract;
using Project.Domain.Identity;
using Project.WebApi.Models.AccountDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly CreateEmployeeCommand cEmployeeCommand;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IAccountService accountService;
        private readonly IConfiguration _config;


        public AccountController(UserManager<AppUser> userManager, CreateEmployeeCommand cEmployeeCommand, RoleManager<IdentityRole> roleManager, IConfiguration config, IAccountService accountService)
        {
            this.userManager = userManager;
            this.cEmployeeCommand = cEmployeeCommand;
            this.roleManager = roleManager;
            this.accountService = accountService;
            this._config = config;



        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserMV user)
        {

            if (!ModelState.IsValid)
                return BadRequest("Geçersiz giriş bilgileri");

            var signInResult = await accountService.SignInForAppUser(user.Email,user.Password);
            if (!await accountService.SignInForAppUser(user.Email, user.Password))
                return NotFound("Kullanıcı bulunamadı");

            var appUser = await userManager.FindByEmailAsync(user.Email);
            var userRoles = await userManager.GetRolesAsync(appUser);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Email, appUser.Email)
            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

          
            return Ok(token);
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            if (await accountService.UpdatePasswordAsync(passwordDto.Email, passwordDto.Password, passwordDto.ConfirmPassword))
                return Ok();
            return BadRequest("Şifreyi kontrol ederek tekrar giriniz lütfen.");

        }


    }
}

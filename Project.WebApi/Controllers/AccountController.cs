using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.Application.DTOs;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Services.Abstract;
using Project.Domain.Entities;
using Project.WebApi.Models.AccountDTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly CreateEmployeeCommand cEmployeeCommand;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IAccountService accountService;
        private readonly IConfiguration _config;
        private readonly JwtConfiguration jwtService;


        public AccountController(UserManager<AppUser> userManager, CreateEmployeeCommand cEmployeeCommand, RoleManager<IdentityRole> roleManager, IConfiguration config, IAccountService accountService, JwtConfiguration jwtService)
        {
            this.userManager = userManager;
            this.cEmployeeCommand = cEmployeeCommand;
            this.roleManager = roleManager;
            this.accountService = accountService;
            this._config = config;
            this.jwtService = jwtService;



        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginUserMV user,CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
                return BadRequest("Geçersiz giriş bilgileri");
            if (!await accountService.SignInForAppUser(user.Email, user.Password))
                return NotFound("Giriş yapılırken bir hata ile karşılaşıldı.");

            var appUser = await userManager.FindByEmailAsync(user.Email);
            var userRoles = await userManager.GetRolesAsync(appUser);
            var claims = new List<Claim>();
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwt = jwtService.Generate(appUser);

            if (jwt==null)
                return BadRequest("token oluşmadı");

            return Ok(jwt);

        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto passwordDto)
        {
            if (!await accountService.IsUserValid(passwordDto.Email))
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            if (!await accountService.IfPasswordMatches(passwordDto.Password, passwordDto.ConfirmPassword))
            {
                return BadRequest("Parolalar eşleşmiyor.");
            }

            if (await accountService.UpdatePasswordAsync(passwordDto.Email, passwordDto.Password, passwordDto.ConfirmPassword))
            {
                return Ok();
            }

            return BadRequest("Parola güncellenemedi.");
        }


    }
}

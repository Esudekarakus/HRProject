﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.Application.DTOs;
using Project.Application.Features.CQRS.Commands.AccountCommands;
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
    [AllowAnonymous]
    public class AccountController : Controller
    {
        
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        private readonly IAccountService accountService;
        private readonly IConfiguration _config;
        private readonly JwtConfiguration jwtService;


        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, IAccountService accountService, JwtConfiguration jwtService)
        {
            this.userManager = userManager;
            
            this.roleManager = roleManager;
            this.accountService = accountService;
            this._config = config;
            this.jwtService = jwtService;



        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginCommand user,CancellationToken cancellationToken)
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

            claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
            claims.Add(new Claim("UserId", appUser.Id));

            var jwt = jwtService.Generate(appUser,claims);

            if (jwt==null)
                return BadRequest("token oluşmadı");

            return Ok(jwt);

        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ForgotPasswordCommand command)
        {
            if (!await accountService.IsUserValid(command.Email))
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            if (!await accountService.IfPasswordMatches(command.Password, command.ConfirmPassword))
            {
                return BadRequest("Parolalar eşleşmiyor.");
            }

            if (await accountService.UpdatePasswordAsync(command.Email, command.Password, command.ConfirmPassword))
            {
                return Ok();
            }

            return BadRequest("Parola güncellenemedi.");
        }


    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.Application.DTOs;
using Project.Application.Features.CQRS.Commands.AccountCommands;
using Project.Application.Services.Abstract;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using Project.Domain.Enum;
using Project.WebApi.DTOs.AccountDTOs;
using Project.WebApi.Models.AccountDTOs;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;
using Project.WebApi.Helpers;

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
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailService emailService;



        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, IAccountService accountService, JwtConfiguration jwtService, IUnitOfWork unitOfWork, IConfiguration _config, IEmailService emailService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.accountService = accountService;
            this._config = config;
            this.jwtService = jwtService;
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
        }


        [HttpPost("GetAppUserDetails")]
        public async Task<IActionResult> GetAppUserDetails([FromBody] AppUserMailDTO email)
        {
            AppUser user = await userManager.FindByEmailAsync(email.mail);
            if (user != null && user.EmployeeID != null)
            {
                Employee employee = await unitOfWork.employeeRepository.FirstOrDefaultAsync(x => x.Id == user.EmployeeID);

                AppUserDetailsDTO detailsDTO = new AppUserDetailsDTO()
                {
                    Email = user.Email,
                    Salary = employee.Salary,
                    SecondLastName = employee.LastName,
                    Status = (Status?)employee.Status,
                    BirthOfPlace = employee.BirthOfPlace,
                    CompanyId = employee.CompanyId,
                    DateOfStart = employee.DateOfStart,
                    DateOfEnd = employee.DateOfEnd,
                    DateOfBirth = employee.DateOfBirth,
                    Department = employee.Department,
                    OffDays = employee.OffDays,
                    //ImageName = command.ImageName,
                    IdendificationNumber = employee.IdendificationNumber,
                    Address = employee.Address,
                    Name = employee.Name,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    Profession = employee.Profession,
                    PhoneNumber = employee.PhoneNumber,
                    PrivateMail = employee.PrivateMail,
                    CreatedDate = employee.CreatedDate
                };
                return Ok(detailsDTO);
            }
            else if (user != null && user.EmployerID != null)
            {
                Employer employer = await unitOfWork.employerRepository.FirstOrDefaultAsync(x => x.Id == user.EmployerID);
                AppUserDetailsDTO detailsDTO2 = new AppUserDetailsDTO()
                {
                    Email = user.Email,
                    Salary = employer.Salary,
                    SecondLastName = employer.LastName,
                    Status = employer.Status,
                    BirthOfPlace = employer.PlaceOfBirth,
                    CompanyId = employer.CompanyId,
                    DateOfStart = employer.DateOfStart,
                    DateOfEnd = employer.DateOfEnd,
                    DateOfBirth = employer.DateOfBirth,
                    Department = employer.Department,
                    OffDays = employer.OffDays,
                    //ImageName = command.ImageName,
                    IdendificationNumber = employer.IdentityNumber,
                    Address = employer.Address,
                    Name = employer.Name,
                    LastName = employer.LastName,
                    MiddleName = employer.MiddleName,
                    Profession = employer.Profession,
                    PhoneNumber = employer.PhoneNumber,
                    PrivateMail = employer.PrivateMail,
                    CreatedDate = employer.CreatedDate
                };
                return Ok(detailsDTO2);
            }
            else
            {
                AppUserDetailsDTO detailsDTO2 = new AppUserDetailsDTO()
                {
                    Email = user.Email,
                    //SecondLastName = user.LastName,
                    //ImageName = command.ImageName,
                    PhoneNumber = user.PhoneNumber,

                };
                return Ok(detailsDTO2);
            }
        }



        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand user, CancellationToken cancellationToken)
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
                claims.Add(new Claim("Role", role));

            }

            claims.Add(new Claim("Email", appUser.Email));
            claims.Add(new Claim("UserId", appUser.Id));

            var jwt = jwtService.Generate(appUser, claims);

            if (jwt == null)
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

            //if (await accountService.UpdatePasswordAsync(command.Email, command.Password, command.ConfirmPassword))
            //{
            //    return Ok();
            //}

            if (await emailService.SendVerificationCodeToUser(command))
                return Ok();

            return BadRequest("Parola güncellenemedi.");
        }

        [HttpPost("VerifyCode")]
        public async Task<IActionResult> VerifyCode(VerifyCodeDTO verifyCodeDTO)
        {
            if (verifyCodeDTO.inputCode == GeneratedVerifyCode.Code)
            {
                if (await accountService.UpdatePasswordAsync(verifyCodeDTO.Email, verifyCodeDTO.Password, verifyCodeDTO.ConfirmPassword))
                {
                    GeneratedVerifyCode.Code = "";
                    return Ok();
                }

            }

            return BadRequest("Kodunuz Hatalıdır lütfen tekrar deneyin.");
        }

    }
}

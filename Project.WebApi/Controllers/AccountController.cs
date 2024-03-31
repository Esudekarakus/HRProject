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
using Project.Application.Features.CQRS.Commands.EmployerCommands;
using Project.Application.Validation;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;

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
        private readonly IWebHostEnvironment environment;
        private readonly CreateEmployerCommandHandler createEmployerCommandHandler;



        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration config, IAccountService accountService, JwtConfiguration jwtService, IUnitOfWork unitOfWork, IConfiguration _config, IEmailService emailService, IWebHostEnvironment environment, CreateEmployerCommandHandler createEmployerCommandHandler)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.accountService = accountService;
            this._config = config;
            this.jwtService = jwtService;
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
            this.createEmployerCommandHandler = createEmployerCommandHandler;
            this.environment = environment;
        }

        [HttpPost("CreateEmployerByAdmin")]
        public async Task<IActionResult> CreateEmployerByAdmin([FromForm] CreateEmployerCommand command)
        {

            var validator = new AddingEmployerValid();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }
            else if (!await IsUserAvailable(command))
            {
                return BadRequest("Eklenmek istenen kullanıcı halihazırda mevcut.");
            }
            else
            {
                await createEmployerCommandHandler.Handle(command);
                // string imageName = await SaveImage(command.ImageFile);

                Employer CreatedUser = await unitOfWork.employerRepository.FirstOrDefaultAsync(x => x.IdentityNumber == command.IdentificationNumber);

                AppUser NewUser = new()
                {
                    Email = CreatedUser.Email,
                    FirstName = CreatedUser.Name,
                    PhoneNumber = CreatedUser.PhoneNumber,
                    UserName = CreatedUser.Email,
                    EmailConfirmed = false,
                    EmployerID = CreatedUser.Id
                };

                var hasher = new PasswordHasher<AppUser>();
                var result = await userManager.CreateAsync(NewUser, "Bilgeadam.123");

                if (result.Succeeded)
                {
                    // Kullanıcı başarıyla oluşturulduysa, kullanıcıyı bulma işlemi

                    AppUser createdUser = await userManager.FindByNameAsync(NewUser.Email);

                    if (createdUser != null)
                    {
                        IdentityRole role = await roleManager.FindByNameAsync("employer");

                        if (role != null)
                        {
                            await userManager.AddToRoleAsync(createdUser, role.Name);

                            await emailService.SendCompanyMailToCreatedEmployee(createdUser.Email, "Bilgeadam.123", command.PrivateMail);
                        }
                        else
                            return BadRequest("Employee role not found.");

                    }
                    else
                        return BadRequest("Created user not found.");

                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description).ToList();
                    return BadRequest(errors);
                }
                return Ok();

            }

        }


        [HttpPost("GetAppUserDetails")]
        public async Task<IActionResult> GetAppUserDetails([FromBody] AppUserMailDTO email)
        {
            AppUser user = await userManager.FindByEmailAsync(email.mail);
            if (user != null && user.EmployeeID != null)
            {
                Employee employee = await unitOfWork.employeeRepository.GetEmployeeByIdWithCompanyAsync((int)user.EmployeeID);
                //Company company = await unitOfWork.companyRepository.FirstOrDefaultAsync(c => c.Id == employee.CompanyId);

                AppUserDetailsDTO detailsDTO = new AppUserDetailsDTO()
                {
                    Email = user.Email,
                    Salary = employee.Salary,
                    SecondLastName = employee.LastName,
                    Status = (Status?)employee.Status,
                    BirthOfPlace = employee.BirthOfPlace,
                    CompanyId = employee.CompanyId,
                    CompanyName = employee.Company.Name,
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
                Employer employer = await unitOfWork.employerRepository.GetEmployerByIdWithCompanyAsync((int)user.EmployerID);
                //Company company = await unitOfWork.companyRepository.FirstOrDefaultAsync(c => c.Id == employer.CompanyId);

                AppUserDetailsDTO detailsDTO2 = new AppUserDetailsDTO()
                {
                    Email = user.Email,
                    Salary = employer.Salary,
                    SecondLastName = employer.LastName,
                    Status = employer.Status,
                    BirthOfPlace = employer.PlaceOfBirth,
                    CompanyId = employer.CompanyId,
                    CompanyName = employer.Company.Name,
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
                //null reference gelmemea için kontrol lazım
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

        [NonAction]
        private async Task<bool> IsUserAvailable(CreateEmployerCommand command)
        {
            var checkUserId = await unitOfWork.employerRepository.GetWhereListAsync(x => x.IdentityNumber == command.IdentificationNumber || x.PhoneNumber == command.PhoneNumber);
            if (checkUserId.Count == 0)
                return true;
            return false;
        }

        //         [NonAction]
        // public async Task<string> SaveImage(IFormFile imageFile)
        // {
        //     string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
        //     imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
        //     var imagePath = Path.Combine(environment.ContentRootPath, "Images", imageName);
        //     using (var fileStream = new FileStream(imagePath, FileMode.Create))
        //     {
        //         await imageFile.CopyToAsync(fileStream);
        //     }
        //     return imageName;
        // }

    }
}

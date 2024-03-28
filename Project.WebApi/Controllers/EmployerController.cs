 using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Features.CQRS.Commands.EmployerCommands;
using Project.Application.Features.CQRS.Handlers.EmployeeHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;
using Project.Application.Features.CQRS.Queries.EmployerQueries;
using Project.Application.Services.Abstract;
using Project.Application.UnitOfWork.Abstract;
using Project.Application.Validation;
using Project.Domain.Entities;
using System;


namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = "Employer")]
    //[Authorize(Roles = "Employer")]
    public class EmployerController : ControllerBase
    {
        private readonly CreateEmployerCommandHandler createEmployerCommandHandler;
        private readonly GetEmployerByIdQueryHandler getEmployerByIdQueryHandler;
        private readonly GetEmployerQueryHandler getEmployerQueryHandler;
        private readonly UpdateEmployerCommandHandler updateEmployerCommandHandler;
        private readonly RemoveEmployerCommandHandler removeEmployerCommandHandler;
        private readonly GetEmployerWithCompanyQueryResultHandler getEmployerWithCompanyQueryResultHandler;
        private readonly GetEmployerByIdWithCompanyQueryHandler getEmployerByIdWithCompanyQueryHandler;
        private readonly CreateEmployeeCommandHandler createEmployee;
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailService mailService;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment environment;

        public EmployerController(CreateEmployerCommandHandler createEmployerCommandHandler, GetEmployerByIdQueryHandler getEmployerByIdQueryHandler, GetEmployerQueryHandler getEmployerQueryHandler, UpdateEmployerCommandHandler updateEmployerCommandHandler, RemoveEmployerCommandHandler removeEmployerCommandHandler, GetEmployerWithCompanyQueryResultHandler getEmployerWithCompanyQueryResultHandler, GetEmployerByIdWithCompanyQueryHandler getEmployerByIdWithCompanyQueryHandler, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, CreateEmployeeCommandHandler createEmployee, IEmailService mailService, RoleManager<IdentityRole> roleManager,IWebHostEnvironment environment)
        {
            this.createEmployerCommandHandler = createEmployerCommandHandler;
            this.getEmployerByIdQueryHandler = getEmployerByIdQueryHandler;
            this.getEmployerQueryHandler = getEmployerQueryHandler;
            this.updateEmployerCommandHandler = updateEmployerCommandHandler;
            this.removeEmployerCommandHandler = removeEmployerCommandHandler;
            this.getEmployerWithCompanyQueryResultHandler = getEmployerWithCompanyQueryResultHandler;
            this.getEmployerByIdWithCompanyQueryHandler= getEmployerByIdWithCompanyQueryHandler;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.createEmployee = createEmployee;
            this.mailService = mailService;
            this.roleManager = roleManager;
            this.environment = environment;
        }

        [HttpPost("CreateEmployerByAdmin")]
        public async Task<IActionResult> CreateEmployerByAdmin([FromForm]CreateEmployerCommand command)
        {
            if (await CheckUserIdsForEmployer(command))
                return BadRequest("Eklenmek istenen kullanıcı halihazırda mevcut.");

            string imageName = await SaveImage(command.ImageFile);
            await createEmployerCommandHandler.Handle(command);

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
                    IdentityRole role = await roleManager.FindByNameAsync("Employer");

                    if (role != null)
                    {
                        await userManager.AddToRoleAsync(createdUser, role.Name);

                        await mailService.SendCompanyMailToCreatedEmployee(createdUser.Email, "Bilgeadam.123", command.PrivateMail);
                    }
                    else
                        return BadRequest("Employer role not found.");

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

        [HttpGet]
        public async Task<IActionResult> GetEmployerList()
        {
            var values = await getEmployerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetEmployerById(int id)
        {

            var value = await getEmployerByIdQueryHandler.Handle(new GetEmployerByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("GetEmployerWithCompanyById")]

        public async Task<IActionResult> GetEmployerByIdWithCompany(int id)
        {
            var value= await getEmployerByIdWithCompanyQueryHandler.Handle(new GetEmployerByIdWithCompanyQuery(id));
            return Ok(value);
        }
        [HttpPost]

        public async Task<IActionResult> CreateEmployer(CreateEmployerCommand command)
        {
            await createEmployerCommandHandler.Handle(command);
            return Ok("İşveren başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveEmployer(int id)
        {
            await removeEmployerCommandHandler.Handle(new RemoveEmployerCommand(id));
            return Ok("İşveren başarıyla silindi");

        }

        [HttpPut("{id}")]

        public async Task<IActionResult>UpdateEmployer(int id,UpdateEmployerCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest("Gönderilen ID ile istek yapılan ID uyuşmuyor.");
            }
            await updateEmployerCommandHandler.Handle(command);
            return Ok("İşveren başarıyla güncellendi");
        }

        [HttpGet("GetEmployerWithCompany")]

        public async Task<IActionResult> GetEmployersWithCompany()
        {
            var values = getEmployerWithCompanyQueryResultHandler.Handle();
            return Ok(values);
        }

        [HttpPost("CreateEmployeeByEmployer")]
        public async Task<IActionResult> CreateEmployeeByEmployer([FromForm] CreateEmployeeCommand command)
        {

            var validator = new AddingPersonelValid();
            var validationResult = await validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(errors);
            }

            if (await CheckUserIds(command))
                return BadRequest("Eklenmek istenen kullanıcı halihazırda mevcut.");

            string imageName = await SaveImage(command.ImageFile);
            await createEmployee.Handle(command);

            Employee CreatedUser = await unitOfWork.employeeRepository.FirstOrDefaultAsync(x => x.IdendificationNumber == command.IdentificationNumber);

            AppUser NewUser = new()
            {
                Email = CreatedUser.Email,
                FirstName=CreatedUser.Name,
                PhoneNumber = CreatedUser.PhoneNumber,
                UserName=CreatedUser.Email,
                EmailConfirmed = false,
                EmployeeID=CreatedUser.Id
            };

            var hasher = new PasswordHasher<AppUser>();
            var result = await userManager.CreateAsync(NewUser, "Bilgeadam.123");

            if (result.Succeeded)
            {
                // Kullanıcı başarıyla oluşturulduysa, kullanıcıyı bulma işlemi

                AppUser createdUser = await userManager.FindByNameAsync(NewUser.Email);

                if (createdUser != null)
                {
                    IdentityRole role = await roleManager.FindByNameAsync("Employee");

                    if (role != null)
                    {
                        await userManager.AddToRoleAsync(createdUser, role.Name);

                        await mailService.SendCompanyMailToCreatedEmployee(createdUser.Email, "Bilgeadam.123", command.PrivateMail);
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

        [NonAction]
        private async Task<bool> CheckUserIds(CreateEmployeeCommand command)
        {
            var checkUserId = await unitOfWork.employerRepository.GetWhereListAsync(x => x.IdentityNumber == command.IdentificationNumber || x.PhoneNumber==command.PhoneNumber);
            if (checkUserId!=null)
                return false;
            return true;
        }

        [NonAction]
        private async Task<bool> CheckUserIdsForEmployer(CreateEmployerCommand command)
        {
            var checkUserId = await unitOfWork.employerRepository.GetWhereListAsync(x => x.IdentityNumber == command.IdentificationNumber || x.PhoneNumber == command.PhoneNumber);
            if (checkUserId != null)
                return false;
            return true;
        }


        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new String(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(environment.ContentRootPath, "Images", imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }
    }
}

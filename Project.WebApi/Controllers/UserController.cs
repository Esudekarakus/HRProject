using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Features.CQRS.Handlers.EmployeeHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using Project.WebApi.DTOs.AccountDTOs;
using Project.WebApi.Models.AccountDTOs;
using System;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly  RoleManager<IdentityRole> roleManager;
        private readonly IWebHostEnvironment environment;

        public UserController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork,RoleManager<IdentityRole> roleManager, IWebHostEnvironment environment)
        {
            this.roleManager=roleManager;
            this.environment = environment;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var value = await userManager.FindByIdAsync(id);
            return Ok(value);

        }


        [HttpPost("GetUserCompanyByUserEmail")]
        public async Task<IActionResult> GetUserCompanyByUserEmail(string email,int id)
        {
            AppUser user = await userManager.FindByEmailAsync(email);
            if(user.EmployeeID!=null){
                Company company1 = await unitOfWork.companyRepository.FirstOrDefaultAsync(x=>x.Employees.FirstOrDefault(x=>x.Email==email).CompanyId==id);
                return Ok(company1);
            }
            Company company = await unitOfWork.companyRepository.FirstOrDefaultAsync(x=>x.Employers.FirstOrDefault(x=>x.Email==email).CompanyId==id);
            return Ok(company);
        }

        

        [HttpPut("UpdateAppUserDetailsById")]
        public async Task<IActionResult> UpdateAppUserDetailsById([FromForm]AppUserUpdateDetailsDTO user)
        {
            AppUser appUser = await userManager.FindByIdAsync(user.Id);
            if(appUser != null)
            {
                
                
                
                
                if (appUser.EmployeeID != null && appUser != null)
                {
                   
                    Employee employee = await unitOfWork.employeeRepository.GetEmployeeByIdWithCompanyAsync((int)appUser.EmployeeID);
                    employee.Address = user.Address;
                    employee.PhoneNumber = user.PhoneNumber;
                    DeleteImage(employee.ImageName);
                    string imageName = await SaveImage(user.ImageFile);
                    employee.ImageName = imageName;
                    employee.ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, employee.ImageName);



                    await unitOfWork.employeeRepository.UpdateAsync(employee);
                    await unitOfWork.CommitAsync();
                    return Ok();
                }
                else if(appUser.EmployerID != null && appUser != null) 
                {
                    Employer employer = await unitOfWork.employerRepository.GetEmployerByIdWithCompanyAsync((int)appUser.EmployerID);
                    employer.Address = user.Address;
                    employer.PhoneNumber = user.PhoneNumber;
                    DeleteImage(employer.ImageName);
                    string imageName = await SaveImage(user.ImageFile);
                    employer.ImageName = imageName; 
                    employer.ImageSrc = String.Format("{0}://{1}{2}/Images/{3}", Request.Scheme, Request.Host, Request.PathBase, employer.ImageName);

                    await unitOfWork.employerRepository.UpdateAsync(employer);
                    await unitOfWork.CommitAsync();
                    return Ok();

                }
            }
         
            return BadRequest();
 
        }

        [HttpPost("CreateAdmin")]
        public async Task<IActionResult> CreateAdmin(CreateAdminDTO createAdmin)
        {

            if(createAdmin!=null){
                AppUser user = new();
                user.Email=createAdmin.Email;
                user.FirstName=createAdmin.Name;
                user.PhoneNumber=createAdmin.PhoneNumber;
                user.UserName=createAdmin.Email;

                var result = await userManager.CreateAsync(user,createAdmin.Password);

                if(result.Succeeded){
                    AppUser createdUser = await userManager.FindByNameAsync(createAdmin.Email);

                    if (createdUser != null)
                    {
                        IdentityRole role = await roleManager.FindByNameAsync("admin");

                        if (role != null)
                        {
                            await userManager.AddToRoleAsync(createdUser, role.Name); 
                            return Ok();              
                        }
                        return BadRequest();
                    }
                    return BadRequest();

                }
                return BadRequest();
                    

            }
            

            return Ok();
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

        [NonAction]
        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(environment.ContentRootPath, "Images", imageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }
    }
}

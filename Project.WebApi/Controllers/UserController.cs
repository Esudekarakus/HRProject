using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Features.CQRS.Handlers.EmployeeHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using Project.WebApi.DTOs.AccountDTOs;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;


        public UserController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var value = await userManager.FindByIdAsync(id);
            return Ok(value);

        }

        [HttpPost("UpdateAppUserDetailsById")]
        public async Task<IActionResult> UpdateAppUserDetailsById(AppUserUpdateDetailsDTO user)
        {
            AppUser appUser = await userManager.FindByEmailAsync(user.Email);
            if(appUser != null)
            {
                if (appUser.EmployeeID != null && appUser != null)
                {
                    Employee employee = await unitOfWork.employeeRepository.GetEmployeeByIdWithCompanyAsync((int)appUser.EmployeeID);
                    employee.Address = user.Address;
                    employee.PhoneNumber = user.PhoneNumber;
                    await unitOfWork.employeeRepository.UpdateAsync(employee);
                    return Ok();
                }
                else if(appUser.EmployerID != null && appUser != null) 
                {
                    Employer employer = await unitOfWork.employerRepository.GetEmployerByIdWithCompanyAsync((int)appUser.EmployerID);
                    employer.Address = user.Address;
                    employer.PhoneNumber = user.PhoneNumber;
                    await unitOfWork.employerRepository.UpdateAsync(employer);
                    return Ok();

                }
            }
         
            return BadRequest();
 
        }
    }
}

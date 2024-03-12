﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Features.CQRS.Commands.EmployerCommands;
using Project.Application.Features.CQRS.Handlers.EmployeeHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;
using Project.Application.Features.CQRS.Queries.EmployeeQueries;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly CreateEmployeeCommandHandler createEmployeeCommandHandler;
        private readonly UpdateEmployeeCommandHandler updateEmployeeCommandHandler;
        private readonly RemoveEmployeeCommandHandler removeEmployeeCommandHandler;
        private readonly GetEmployeeByIdWithCompanyHandler getEmployeeByIdWithCompanyHandler;
        private readonly GetEmployeeWithCompanyHandler getEmployeeWithCompanyHandler;

        public EmployeeController(CreateEmployeeCommandHandler createEmployeeCommandHandler, UpdateEmployeeCommandHandler updateEmployeeCommandHandler, RemoveEmployeeCommandHandler removeEmployeeCommandHandler, GetEmployeeByIdWithCompanyHandler getEmployeeByIdWithCompanyHandler, GetEmployeeWithCompanyHandler getEmployeeWithCompanyHandler)
        {
            this.createEmployeeCommandHandler = createEmployeeCommandHandler;
            this.updateEmployeeCommandHandler = updateEmployeeCommandHandler;
            this.removeEmployeeCommandHandler = removeEmployeeCommandHandler;
            this.getEmployeeByIdWithCompanyHandler = getEmployeeByIdWithCompanyHandler;
            this.getEmployeeWithCompanyHandler = getEmployeeWithCompanyHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesWithCompany()
        {
            var values = getEmployeeWithCompanyHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult>GetEmployeeByIdWithCompany(int id)
        {
            var value= await getEmployeeByIdWithCompanyHandler.Handle(new GetEmployeeByIdWithCompanyQuery(id));
            return Ok(value);
        }
        [HttpPost]

        public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand command)
        {
            await createEmployeeCommandHandler.Handle(command);
            return Ok("Çalışan başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await removeEmployeeCommandHandler.Handle(new RemoveEmployeeCommand(id));
            return Ok("Çalışan başarıyla silindi");

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Gönderilen ID ile istek yapılan ID uyuşmuyor.");
            }
            await updateEmployeeCommandHandler.Handle(command);
            return Ok("Çalışan başarıyla güncellendi");
        }
    }
}
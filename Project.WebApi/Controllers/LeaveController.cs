﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.Features.CQRS.Commands.LeaveCommands;
using Project.Application.Features.CQRS.Handlers.AdvanceHandlers;
using Project.Application.Features.CQRS.Handlers.ExpenseHandlers;
using Project.Application.Features.CQRS.Handlers.LeaveHandler;
using Project.Application.Features.CQRS.Queries.AdvanceQueries;
using Project.Application.Features.CQRS.Queries.ExpenseQueries;
using Project.Application.Features.CQRS.Queries.LeaveQueries;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly CreateLeaveCommandHandler createLeaveCommandHandler;
        private readonly UpdateLeaveCommandHandler updateLeaveCommandHandler;
        private readonly RemoveLeaveCommandHandler removeLeaveCommandHandler;
        private readonly GetLeaveByEmployeeIdQueryResultHandler getLeaveByEmployeeIdQueryResultHandler;
        private readonly GetLeaveQueryResultHandler getLeaveQueryResultHandler;
        private readonly GetLeaveByCompanyIdQueryResultHandler getLeaveByCompanyIdQueryResultHandler;

        public LeaveController(CreateLeaveCommandHandler createLeaveCommandHandler, UpdateLeaveCommandHandler updateLeaveCommandHandler, RemoveLeaveCommandHandler removeLeaveCommandHandler, GetLeaveByEmployeeIdQueryResultHandler getLeaveByEmployeeIdQueryResultHandler, GetLeaveQueryResultHandler getLeaveQueryResultHandler, GetLeaveByCompanyIdQueryResultHandler getLeaveByCompanyIdQueryResultHandler)
        {
            this.createLeaveCommandHandler = createLeaveCommandHandler;
            this.updateLeaveCommandHandler = updateLeaveCommandHandler;
            this.removeLeaveCommandHandler = removeLeaveCommandHandler;
            this.getLeaveByEmployeeIdQueryResultHandler = getLeaveByEmployeeIdQueryResultHandler;
            this.getLeaveQueryResultHandler = getLeaveQueryResultHandler;
            this.getLeaveByCompanyIdQueryResultHandler = getLeaveByCompanyIdQueryResultHandler;
        }


        [HttpGet]

        public async Task<IActionResult> GetLeaveWithEmployee()
        {
            var values = getLeaveQueryResultHandler.Handle();
            if (values == null)
                return NotFound();
            return Ok(values);
        }
        //liste çevir
        [HttpGet("id")]
        public async Task<IActionResult> GetLeaveByEmployeeId(int id)
        {
            var leave = await getLeaveByEmployeeIdQueryResultHandler.Handle(new GetLeaveByEmployerIdQuery(id));
            return Ok(leave);
        }

        [HttpGet("GetLeaveByCompanyId")]
        public async Task<IActionResult> GetExpensesByCompanyId(int id)
        {
            var leaves = await getLeaveByCompanyIdQueryResultHandler.Handle(new GetLeaveByCompanyIdQuery(id));
            return Ok(leaves);
        }
        [HttpPost]

        public async Task<IActionResult> CreateLeave(CreateLeaveCommand command)
        {

            await createLeaveCommandHandler.Handle(command);
            return Ok("Avans başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await removeLeaveCommandHandler.Handle(new RemoveLeaveCommand(id));
            return Ok("İzin başarıyla silindi");

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateEmployee(UpdateLeaveCommand command)
        {
            await updateLeaveCommandHandler.Handle(command);
            return Ok("İzin başarıyla güncellendi");

        }
    }
}

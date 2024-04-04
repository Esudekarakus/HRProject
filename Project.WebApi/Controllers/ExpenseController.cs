using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.Features.CQRS.Commands.ExpenseCommands;
using Project.Application.Features.CQRS.Handlers.AdvanceHandlers;
using Project.Application.Features.CQRS.Handlers.ExpenseHandlers;
using Project.Application.Features.CQRS.Queries.AdvanceQueries;
using Project.Application.Features.CQRS.Queries.ExpenseQueries;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly CreateExpenseCommandHandler _createExpenseCommandHandler;
        private readonly UpdateExpenseCommandHandler _updateExpenseCommandHandler;
        private readonly RemoveExpenseCommandHandler _removeExpenseCommandHandler;
        private readonly GetExpensesWithEmployeesQueryHandler _getExpensesWithEmployeesCommandHandler;
        private readonly GetExpenseByEmployeeIdQueryHandler _getExpenseByEmployeeIdQueryHandler;
        private readonly IWebHostEnvironment _environment;
        private readonly GetExpenseByCompanyIdQueryHandler getExpenseByCompanyIdQueryHandler;
        private readonly IUnitOfWork unitOfWork;

        public ExpenseController(CreateExpenseCommandHandler createExpenseCommandHandler, UpdateExpenseCommandHandler updateExpenseCommandHandler, RemoveExpenseCommandHandler removeExpenseCommandHandler, GetExpensesWithEmployeesQueryHandler getExpensesWithEmployeesCommandHandler, GetExpenseByEmployeeIdQueryHandler getExpenseByEmployeeIdQueryHandler, IWebHostEnvironment environment, GetExpenseByCompanyIdQueryHandler getExpenseByCompanyIdQueryHandler,IUnitOfWork unitOfWork)
        {
            _createExpenseCommandHandler = createExpenseCommandHandler;
            _updateExpenseCommandHandler = updateExpenseCommandHandler;
            _removeExpenseCommandHandler = removeExpenseCommandHandler;
            _getExpensesWithEmployeesCommandHandler = getExpensesWithEmployeesCommandHandler;
            _getExpenseByEmployeeIdQueryHandler = getExpenseByEmployeeIdQueryHandler;
            this._environment = environment;
            this.getExpenseByCompanyIdQueryHandler = getExpenseByCompanyIdQueryHandler;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]

        public async Task<IActionResult> GetExpenseWithEmployee()
        {
            var values = _getExpensesWithEmployeesCommandHandler.Handle();
            if (values == null)
                return NotFound();
            return Ok(values);
        }
        //liste çevir
        [HttpGet("id")]
        public async Task<IActionResult> GetExpensesByEmployeeId(int id)
        {
            var expenses= await _getExpenseByEmployeeIdQueryHandler.Handle(new GetExpenseByEmployeeIdQuery(id));
            return Ok(expenses);
            //var expenses = await unitOfWork.expenseRepository.GetExpenseWithEmployeeByEmployeeId(id);
            //if(expenses !=null)
            //{
            //    foreach(var expense in expenses)
            //    {
            //        expense.FileSrc= String.Format("{0}://{1}{2}/Expenses/{3}", Request.Scheme, Request.Host, Request.PathBase, expense.FileName);
            //    }
            //}
            //var options = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve
            //};
            //return Ok(JsonSerializer.Serialize(expenses, options));
        }

        [HttpGet("GetExpenseByCompanyId")]
        public async Task<IActionResult> GetExpensesByCompanyId(int id)
        {
            var expenses = await getExpenseByCompanyIdQueryHandler.Handle(new GetExpenseByCompanyIdQuery(id));
            return Ok(expenses);
        }
        [HttpPost]

        public async Task<IActionResult> CreateExpense([FromForm] CreateExpenseCommand command)
        {
            string fileName = await SaveFile(command.FormFile);
            command.FileName = fileName;
            await _createExpenseCommandHandler.Handle(command);
            return Ok("Harcamalar başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveExpense(int id)
        {
            await _removeExpenseCommandHandler.Handle(new RemoveExpenseCommand(id));
            return Ok("Avans başarıyla silindi");

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateExpense(UpdateExpenseCommand command)
        {
            await _updateExpenseCommandHandler.Handle(command);
            return Ok("Avans başarıyla güncellendi");

        }

        [NonAction]
        public async Task<string> SaveFile(IFormFile file)
        {
            string fileName = new String(Path.GetFileNameWithoutExtension(file.FileName).Take(10).ToArray()).Replace(' ', '-');
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(file.FileName);
            var imagePath = Path.Combine(_environment.ContentRootPath, "Expenses", fileName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return fileName;
        }
    }
}

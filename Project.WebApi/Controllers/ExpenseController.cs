using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.Features.CQRS.Commands.ExpenseCommands;
using Project.Application.Features.CQRS.Handlers.AdvanceHandlers;
using Project.Application.Features.CQRS.Handlers.ExpenseHandlers;
using Project.Application.Features.CQRS.Queries.AdvanceQueries;
using Project.Application.Features.CQRS.Queries.ExpenseQueries;

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

        public ExpenseController(CreateExpenseCommandHandler createExpenseCommandHandler, UpdateExpenseCommandHandler updateExpenseCommandHandler, RemoveExpenseCommandHandler removeExpenseCommandHandler, GetExpensesWithEmployeesQueryHandler getExpensesWithEmployeesCommandHandler, GetExpenseByEmployeeIdQueryHandler getExpenseByEmployeeIdQueryHandler)
        {
            _createExpenseCommandHandler = createExpenseCommandHandler;
            _updateExpenseCommandHandler = updateExpenseCommandHandler;
            _removeExpenseCommandHandler = removeExpenseCommandHandler;
            _getExpensesWithEmployeesCommandHandler = getExpensesWithEmployeesCommandHandler;
            _getExpenseByEmployeeIdQueryHandler = getExpenseByEmployeeIdQueryHandler;
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
            var advances = await _getExpenseByEmployeeIdQueryHandler.Handle(new GetExpenseByEmployeeIdQuery(id));
            return Ok(advances);
        }
        [HttpPost]

        public async Task<IActionResult> CreateExpense(CreateExpenseCommand command)
        {

            await _createExpenseCommandHandler.Handle(command);
            return Ok("Harcamalar başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveExpense(int id)
        {
            await _getExpenseByEmployeeIdQueryHandler.Handle(new GetExpenseByEmployeeIdQuery(id));
            return Ok("Avans başarıyla silindi");

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateExpense(UpdateExpenseCommand command)
        {
            await _updateExpenseCommandHandler.Handle(command);
            return Ok("Avans başarıyla güncellendi");

        }
    }
}

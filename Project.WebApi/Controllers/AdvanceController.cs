using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.Features.CQRS.Handlers.AdvanceHandlers;
using Project.Application.Features.CQRS.Handlers.EmployeeHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;
using Project.Application.Features.CQRS.Queries.AdvanceQueries;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvanceController : ControllerBase
    {
        private readonly CreateAdvanceCommandHandler createAdvanceCommandHandler;
        private readonly UpdateAdvanceCommandHandler updateAdvanceCommandHandler;
        private readonly RemoveAdvanceCommandHandler removeAdvanceCommandHandler;
        private readonly GetAdvanceByEmployeeIdQueryResultHandler getAdvanceByEmployeeIdQueryResultHandler;
        private readonly GetAdvanceQueryResultHandler getAdvanceQueryResultHandler;
        private readonly GetAdvanceByCompanyIdQueryHandler getAdvanceByCompanyIdQueryHandler;

        public AdvanceController(CreateAdvanceCommandHandler createAdvanceCommandHandler, UpdateAdvanceCommandHandler updateAdvanceCommandHandler, RemoveAdvanceCommandHandler removeAdvanceCommandHandler, GetAdvanceByEmployeeIdQueryResultHandler getAdvanceByEmployeeIdQueryResultHandler, GetAdvanceQueryResultHandler getAdvanceQueryResultHandler,GetAdvanceByCompanyIdQueryHandler getAdvanceByCompanyIdQueryHandler)
        {
            this.createAdvanceCommandHandler = createAdvanceCommandHandler;
            this.updateAdvanceCommandHandler = updateAdvanceCommandHandler;
            this.removeAdvanceCommandHandler = removeAdvanceCommandHandler;
            this.getAdvanceByEmployeeIdQueryResultHandler = getAdvanceByEmployeeIdQueryResultHandler;
            this.getAdvanceQueryResultHandler = getAdvanceQueryResultHandler;
            this.getAdvanceByCompanyIdQueryHandler = getAdvanceByCompanyIdQueryHandler;
        }

        [HttpGet]

        public async Task<IActionResult> GetAdvanceWithEmployee()
        {
            var values = getAdvanceQueryResultHandler.Handle();
            if(values == null) 
                    return NotFound();
            return Ok(values);
        }
        //liste çevir
        [HttpGet("id")]
        public async Task<IActionResult>GetAdvancesByEmployeeId(int id)
        {
            var advances = await getAdvanceByEmployeeIdQueryResultHandler.Handle(new GetByEmployeeIdQuery(id));
            return Ok(advances);
        }

        [HttpGet("GetAdvanceByCompanyId")]
        public async Task<IActionResult> GetAdvancesByCompanyId(int id)
        {
            var advances = await getAdvanceByCompanyIdQueryHandler.Handle(new GetAdvanceByCompanyId(id));
            return Ok(advances);
        }
        [HttpPost]

        public async Task<IActionResult> CreateAdvance(CreateAdvanceCommand command)
        {
            
            await createAdvanceCommandHandler.Handle(command);
            return Ok("Avans başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await removeAdvanceCommandHandler.Handle(new RemoveAdvanceCommand(id));
            return Ok("Avans başarıyla silindi");

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateEmployee(UpdateAdvanceCommand  command)
        {
            await updateAdvanceCommandHandler.Handle(command);
            return Ok("Avans başarıyla güncellendi");
          
        }
    }
}

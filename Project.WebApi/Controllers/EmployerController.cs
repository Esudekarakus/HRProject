using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.EmployerCommands;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;
using Project.Application.Features.CQRS.Queries.EmployerQueries;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly CreateEmployerCommandHandler createEmployerCommandHandler;
        private readonly GetEmployerByIdQueryHandler getEmployerByIdQueryHandler;
        private readonly GetEmployerQueryHandler getEmployerQueryHandler;
        private readonly UpdateEmployerCommandHandler updateEmployerCommandHandler;
        private readonly RemoveEmployerCommandHandler removeEmployerCommandHandler;

        public EmployerController(CreateEmployerCommandHandler createEmployerCommandHandler, GetEmployerByIdQueryHandler getEmployerByIdQueryHandler, GetEmployerQueryHandler getEmployerQueryHandler, UpdateEmployerCommandHandler updateEmployerCommandHandler, RemoveEmployerCommandHandler removeEmployerCommandHandler)
        {
            this.createEmployerCommandHandler = createEmployerCommandHandler;
            this.getEmployerByIdQueryHandler = getEmployerByIdQueryHandler;
            this.getEmployerQueryHandler = getEmployerQueryHandler;
            this.updateEmployerCommandHandler = updateEmployerCommandHandler;
            this.removeEmployerCommandHandler = removeEmployerCommandHandler;
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

        [HttpPut]

        public async Task<IActionResult>UpdateEmployer(UpdateEmployerCommand command)
        {
            await updateEmployerCommandHandler.Handle(command);
            return Ok("İşveren başarıyla güncellendi");
        }
    }
}

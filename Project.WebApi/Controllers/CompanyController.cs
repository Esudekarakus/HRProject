using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Features.CQRS.Commands.CompanyCommands;
using Project.Application.Features.CQRS.Commands.EmployerCommands;
using Project.Application.Features.CQRS.Handlers.CompanyHandlers;
using Project.Application.Features.CQRS.Handlers.EmployerQueries;
using Project.Application.Features.CQRS.Queries.CompanQueries;
using Project.Application.Features.CQRS.Queries.EmployerQueries;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CreateCompanyCommandHandler createCompanyCommandHandler;
        private readonly GetCompanyByIdQueryHandler getCompanyByIdQueryHandler;
        private readonly GetCompanyQueryHandler getCompanyQueryHandler;
        private readonly UpdateCompanyCommandHandler updateCompanyCommandHandler;
        private readonly RemoveCompanyCommandHandler removeCompanyCommandHandler;

        public CompanyController(CreateCompanyCommandHandler createCompanyCommandHandler, GetCompanyByIdQueryHandler getCompanyByIdQueryHandler, GetCompanyQueryHandler getCompanyQueryHandler, UpdateCompanyCommandHandler updateCompanyCommandHandler, RemoveCompanyCommandHandler removeCompanyCommandHandler)
        {
            this.createCompanyCommandHandler = createCompanyCommandHandler;
            this.getCompanyByIdQueryHandler = getCompanyByIdQueryHandler;
            this.getCompanyQueryHandler = getCompanyQueryHandler;
            this.updateCompanyCommandHandler = updateCompanyCommandHandler;
            this.removeCompanyCommandHandler = removeCompanyCommandHandler;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanyList()
        {
            var values = await getCompanyQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {

            var value = await getCompanyByIdQueryHandler.Handle(new GetCompanyByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]

        public async Task<IActionResult> CreateCompany(CreateCompanyCommand command)
        {
            await createCompanyCommandHandler.Handle(command);
            return Ok("Şirket başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCompany(int id)
        {
            await removeCompanyCommandHandler.Handle(new RemoveCompanyCommand(id));
            return Ok("Şirket başarıyla silindi");

        }

        [HttpPut]

        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommand command)
        {
            await updateCompanyCommandHandler.Handle(command);
            return Ok("Şirket başarıyla güncellendi");
        }
    }
}

using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment environment;

        public EmployeeController(CreateEmployeeCommandHandler createEmployeeCommandHandler, UpdateEmployeeCommandHandler updateEmployeeCommandHandler, RemoveEmployeeCommandHandler removeEmployeeCommandHandler, GetEmployeeByIdWithCompanyHandler getEmployeeByIdWithCompanyHandler, GetEmployeeWithCompanyHandler getEmployeeWithCompanyHandler, IWebHostEnvironment environment)
        {
            this.createEmployeeCommandHandler = createEmployeeCommandHandler;
            this.updateEmployeeCommandHandler = updateEmployeeCommandHandler;
            this.removeEmployeeCommandHandler = removeEmployeeCommandHandler;
            this.getEmployeeByIdWithCompanyHandler = getEmployeeByIdWithCompanyHandler;
            this.getEmployeeWithCompanyHandler = getEmployeeWithCompanyHandler;
            this.environment = environment;
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

        public async Task<IActionResult> CreateEmployee([FromForm]CreateEmployeeCommand command)
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

            try
            {
                // Resmi kaydet
                string imageName = await SaveImage(command.ImageFile);

                // Komutu güncelleme işleyicisine
                await updateEmployeeCommandHandler.Handle(command);

                return Ok("Çalışan başarıyla güncellendi");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
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

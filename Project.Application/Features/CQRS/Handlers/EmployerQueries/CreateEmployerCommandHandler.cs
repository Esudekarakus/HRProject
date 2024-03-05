using Project.Application.Features.CQRS.Commands.EmployerCommands;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployerQueries
{
    public class CreateEmployerCommandHandler
    {
        private readonly IRepository<Employer> repo;

        public CreateEmployerCommandHandler(IRepository<Employer> repo) 
        {
            this.repo = repo;
        }

        public async Task Handle(CreateEmployerCommand command)
        {
            await repo.CreateAsync(new Employer
            {
                Name=command.Name,
                SecondName=command.SecondName,
                LastName=command.LastName,
                SecondLastName=command.LastName,
                DateOfBirth=command.DateOfBirth,
                DateOfStart=command.DateOfStart,
                Status=command.Status,
                ImagePath=command.ImagePath,
                Address=command.Address,
                Salary=command.Salary,
                Profession=command.Profession,
                PhoneNumber=command.PhoneNumber,
                DateOfEnd=command.DateOfEnd,
                OffDays=command.OffDays,
                CompanyId=command.CompanyId,
                

            });
        }
    }
}

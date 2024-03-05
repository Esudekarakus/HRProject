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
    public class UpdateEmployerCommandHandler
    {
        private readonly IRepository<Employer> repository;

        public UpdateEmployerCommandHandler(IRepository<Employer> repo) 
        {
            this.repository = repo;
        }

        public async Task Handle(UpdateEmployerCommand command)
        {
            var values = await repository.GetByIdAsync(command.Id);

            values.Name = command.Name;
            values.LastName = command.LastName;
            values.SecondName = command.SecondName;
            values.SecondLastName = command.SecondLastName;
            values.PhoneNumber = command.PhoneNumber;
            values.Address = command.Address;
            values.Profession= command.Profession;
            values.Salary = command.Salary;
            values.Status = command.Status;
            values.DateOfStart = command.DateOfStart;
            values.DateOfEnd = command.DateOfEnd;
            values.Company= command.Company;
            values.OffDays= command.OffDays;
            values.ImagePath= command.ImagePath;
            values.CompanyId= command.CompanyId;

            await repository.UpdateAsync(values);
        }
    }
}

using Project.Application.Features.CQRS.Commands.EmployerCommands;
using Project.Application.Repositories.Abstract;
using Project.Application.UnitOfWork.Abstract;
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
        private readonly IUnitOfWork unitOfWork;

        public UpdateEmployerCommandHandler(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateEmployerCommand command)
        {
            var values = await unitOfWork.employerRepository.GetByIdAsync(command.Id);

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
            
            values.OffDays= command.OffDays;
            values.ImagePath= command.ImagePath;
            values.CompanyId= command.CompanyId;
            values.UpdatedDate = DateTime.Now;
            values.DateOfBirth= DateTime.Now;
            values.IdentityNumber= command.IdentityNumber;

            await unitOfWork.employerRepository.UpdateAsync(values);
        }
    }
}

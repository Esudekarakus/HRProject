using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployeeHandlers
{
    public class CreateEmployeeCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateEmployeeCommand command)
        {
            await unitOfWork.employeeRepository.CreateAsync(new Employee
            {
                Salary = command.Salary,
                SecondLastName = command.LastName,
                Status = command.Status,
                BirthOfPlace = command.BirthOfPlace,
                CompanyId = command.CompanyId,
                DateOfStart = command.DateOfStart,
                DateOfEnd = command.DateOfEnd,
                DateOfBirth = command.DateOfBirth,
                Department = command.Department,
                OffDays = command.OffDays,
                //ImageName = command.ImageName,
                IdendificationNumber = command.IdentificationNumber,
                Address=command.Address,
                Name = command.Name,
                LastName = command.LastName,
                MiddleName = command.MiddleName,
                Profession = command.Profession,
                PhoneNumber = command.PhoneNumber,
                PrivateMail = command.PrivateMail

            });
        }
    }
}

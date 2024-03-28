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
    public class CreateEmployerCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateEmployerCommandHandler(IUnitOfWork unitOfWork) 
        {
             this.unitOfWork=unitOfWork;
        }
        
        public async Task Handle(CreateEmployerCommand command)
        {
            await unitOfWork.employerRepository.CreateAsync(new Employer
            {
                Salary = command.Salary,
                SecondLastName = command.LastName,
                Status = (Domain.Enum.Status)command.Status,
                PlaceOfBirth = command.BirthOfPlace,
                CompanyId = command.CompanyId,
                DateOfStart = command.DateOfStart,
                DateOfEnd = command.DateOfEnd,
                DateOfBirth = command.DateOfBirth,
                Department = command.Department,
                OffDays = command.OffDays,
                ImageName = command.ImageName,
                IdentityNumber = command.IdentificationNumber,
                Address = command.Address,
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

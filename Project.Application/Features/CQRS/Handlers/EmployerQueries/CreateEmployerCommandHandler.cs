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

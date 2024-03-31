using Project.Application.Features.CQRS.Commands.LeaveCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.LeaveHandler
{
    public class CreateLeaveCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateLeaveCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateLeaveCommand command)
        {
            await unitOfWork.leaveRepository.CreateAsync(new Domain.Entities.Leave
            {
                Type = command.Type,
                Description = command.Description,
               
                DueDate = command.DueDate,
                LeaveDate = command.LeaveDate,
                NumberOfDays = command.NumberOfDays,
                EmployeeId = command.EmployeeId,
            });
            await unitOfWork.CommitAsync();

        }
    }
}

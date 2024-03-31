using Project.Application.Features.CQRS.Commands.LeaveCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.LeaveHandler
{
    public class RemoveLeaveCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveLeaveCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public async Task Handle(RemoveLeaveCommand command)
        {
           var value= await unitOfWork.leaveRepository.GetByIdAsync(command.Id);
            if (value != null)
            {
                await unitOfWork.leaveRepository.RemoveAsync(value);
                await unitOfWork.CommitAsync();
            }

        }
    }
}

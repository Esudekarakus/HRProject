using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.AdvanceHandlers
{
    public class UpdateAdvanceCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateAdvanceCommandHandler(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateAdvanceCommand command)
        {
            var values= await unitOfWork.advanceRepository.GetByIdAsync(command.Id);
            if(values != null)
            {
                values.ApprovalDate=command.ApprovalDate;
                values.UpdatedDate = DateTime.Now;
                values.ApprovalStatus=command.ApprovalStatus;

            }
        }
    }
}

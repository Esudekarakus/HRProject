using Project.Application.Features.CQRS.Commands.ExpenseCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.ExpenseHandlers
{
    public class UpdateExpenseCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateExpenseCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateExpenseCommand command)
        {
            var values= await unitOfWork.expenseRepository.GetByIdAsync(command.Id);
            if (values != null)
            {
                if (command.ApprovalStatus == 2)
                {
                    values.ApprovalDate = DateTime.Now;
                }
                else
                {
                    values.ApprovalDate = null;
                }
                values.UpdatedDate = DateTime.Now;
                values.ApprovalStatus = command.ApprovalStatus;

                await unitOfWork.expenseRepository.UpdateAsync(values);
                await unitOfWork.CommitAsync();
            }

        }
    }
}

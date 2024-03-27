using Project.Application.Features.CQRS.Commands.ExpenseCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.ExpenseHandlers
{
    public class CreateExpenseCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateExpenseCommandHandler(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateExpenseCommand command)
        {
            try
            {
                await unitOfWork.expenseRepository.CreateAsync(new Domain.Entities.Expense
                {
                    Amount = command.Amount,
                    InvoicePath = command.InvoicePath,
                    Description = command.Description,
                    Currency = command.Currency,
                    ExpenseDate = DateTime.Now,
                    ExpenseType = command.ExpenseType,
                    EmployeeId = command.EmployeeId,
                    FileName = command.FileName,

                });
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

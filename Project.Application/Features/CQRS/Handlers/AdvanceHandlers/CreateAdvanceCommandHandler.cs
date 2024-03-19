using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.AdvanceHandlers
{
    public class CreateAdvanceCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateAdvanceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task Handle(CreateAdvanceCommand command)
        {
            await unitOfWork.advanceRepository.CreateAsync(new Advance
            {
                AdvanceType = command.AdvanceType,
                Description = command.Description,
                Amount = command.Amount,
                Currency = command.Currency,
                EmployeeId = command.EmployeeId,

            });
        }
    }
}

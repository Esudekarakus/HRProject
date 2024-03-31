using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.AdvanceHandlers
{
    public class RemoveAdvanceCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveAdvanceCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveAdvanceCommand command)
        {
            var value= await unitOfWork.advanceRepository.GetByIdAsync(command.Id);
            if (value != null)
                await unitOfWork.advanceRepository.RemoveAsync(value);
                await unitOfWork.CommitAsync();
        }
    }
}

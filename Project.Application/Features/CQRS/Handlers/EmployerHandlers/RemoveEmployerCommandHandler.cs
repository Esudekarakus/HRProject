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
    public class RemoveEmployerCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;
        public RemoveEmployerCommandHandler(IUnitOfWork unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveEmployerCommand removeCommand)
        {
            var value = await unitOfWork.employerRepository.GetByIdAsync(removeCommand.Id);
            await unitOfWork.employerRepository.RemoveAsync(value);
        }
    }
}

using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployeeHandlers
{
    public class RemoveEmployeeCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveEmployeeCommand command)
        {
            var values = await unitOfWork.employeeRepository.GetByIdAsync(command.Id);

            await unitOfWork.employeeRepository.RemoveAsync(values);

        }
    }
}

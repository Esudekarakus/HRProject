using Project.Application.Features.CQRS.Commands.EmployeeCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployeeHandlers
{
    public class UpdateEmployeeCommandHandler
    {
        private IUnitOfWork unitOfWork;

        public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateEmployeeCommand command)
        {
            var values = await unitOfWork.employeeRepository.GetByIdAsync(command.Id);
            if (values == null)
            {
                values.PhoneNumber= command.PhoneNumber;
                values.Address= command.Address;
                await unitOfWork.employeeRepository.UpdateAsync(values);

            }
        }
    }
}

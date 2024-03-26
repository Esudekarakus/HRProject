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

        public async Task Handle( UpdateEmployeeCommand command)
        {
            var employee = await unitOfWork.employeeRepository.GetByIdAsync(command.Id);
            if (employee == null)
            {
                throw new Exception("Belirtilen ID ile çalışan bulunamadı.");
            }

            // Adres ve telefon numarasını güncelle
            employee.PhoneNumber = command.PhoneNumber;
            employee.Address = command.Address;

            // Resim adını güncelle (eğer bir resim adı varsa)
            if (!string.IsNullOrEmpty(command.ImageName))
            {
                employee.ImageName = command.ImageName;
            }

            await unitOfWork.employeeRepository.UpdateAsync(employee);
            await unitOfWork.CommitAsync(); // Transaksiyonu kaydet
        }
    }
}

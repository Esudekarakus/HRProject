using Project.Application.Features.CQRS.Commands.CompanyCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.CompanyHandlers
{
    public class UpdateCompanyCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public UpdateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public async Task Handle(UpdateCompanyCommand command)
        {
            var values = await unitOfWork.companyRepository.GetByIdAsync(command.Id);
            if(values != null)
            {
                values.PhoneNumber = command.PhoneNumber;
                values.VatNumber = command.VatNumber;
                values.Address = command.Address;
                values.Address = command.Address;
                values.FoundationDate = command.FoundationDate;

                await unitOfWork.companyRepository.UpdateAsync(values);
                await unitOfWork.CommitAsync();
            }
            
        }
    }
}

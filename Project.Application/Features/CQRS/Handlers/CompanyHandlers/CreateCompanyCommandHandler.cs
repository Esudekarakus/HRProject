using Project.Application.Features.CQRS.Commands.CompanyCommands;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.CompanyHandlers
{
    public class CreateCompanyCommandHandler
    {

        private readonly IUnitOfWork unitOfWork;

        public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCompanyCommand command)
        {
            await unitOfWork.companyRepository.CreateAsync(new Company
            {
                Address=command.Address,
                PhoneNumber=command.PhoneNumber,
                VatNumber=command.VatNumber,
                FoundationDate=command.FoundationDate,
                Name=command.Name,
            });
        }
    }
}

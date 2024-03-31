using Project.Application.Features.CQRS.Commands.CompanyCommands;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.CompanyHandlers
{
    public class RemoveCompanyCommandHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Handle(RemoveCompanyCommand command)
        {
            var value = await unitOfWork.companyRepository.GetByIdAsync(command.Id);
            await unitOfWork.companyRepository.RemoveAsync(value);
            await unitOfWork.CommitAsync();
        }
    }
}

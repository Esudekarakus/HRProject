using Project.Application.Features.CQRS.Commands.AdvanceCommands;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using Project.Domain.Enum;
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

       public int GetCurrencyAsInt (Currency currency)
        {
            switch (currency)
            {
                case Currency.TL:
                    return 1;
                case Currency.USD:
                    return 2;
                case Currency.EUR:
                    return 3; 
                default:
                    return 0;
                    
            }

        }
        public int GetAdvanceTypeAsInt(AdvanceType advance)
        {
            switch (advance)
            {
                case AdvanceType.Individual:
                    return 1;
                case AdvanceType.Medical:
                    return 2;
                case AdvanceType.Travel:
                    return 3;
                default:
                    return 0;
                   
            }

        }
        public async Task Handle(CreateAdvanceCommand command)
        {
            try 
            {   
                

                await unitOfWork.advanceRepository.CreateAsync(new Advance
                {
                    AdvanceTypeInt = command.AdvanceType,
                    Description = command.Description,
                    Amount = command.Amount,
                    CurrencyInt = command.Currency,
                    EmployeeId = command.EmployeeId,
                });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

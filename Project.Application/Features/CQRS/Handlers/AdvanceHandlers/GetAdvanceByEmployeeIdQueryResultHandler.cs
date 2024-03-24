using Project.Application.Features.CQRS.Queries.AdvanceQueries;
using Project.Application.Features.CQRS.Results.AdvanceResults;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.AdvanceHandlers
{
    public class GetAdvanceByEmployeeIdQueryResultHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAdvanceByEmployeeIdQueryResultHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public ApprovalStatus GetEnum(int approvalint)
        {
            switch (approvalint)
            {
                case 1:
                    return ApprovalStatus.Waiting;
                case 2:
                    return ApprovalStatus.Approved;

                default: return ApprovalStatus.Waiting;
            }


        }
        public AdvanceType GetEnumAdvance(int advanceInt)
        {
            switch (advanceInt)
            {
                case 1:
                    return AdvanceType.Individual;
                case 2:
                    return AdvanceType.Medical;
                case 3:
                    return AdvanceType.Travel;

                default: return AdvanceType.Individual;
            }


        }

        public Currency GetCurrencyEnum(int curr)
        {
            switch (curr)
            {
                case 1:
                    return Currency.TL;
                case 2:
                    return Currency.USD;
                case 3:
                    return Currency.EUR;

                default: return Currency.TL;
            }


        }
        public async Task<List<GetAdvanceByEmployeeIdQueryResult>> Handle(GetByEmployeeIdQuery query)
        {
            var values= await unitOfWork.advanceRepository.GetAdvanceWithEmployeeWithEmployeeId(query.EmployeeId);
            return values.Select(x=> new GetAdvanceByEmployeeIdQueryResult
            {
                Id = x.Id,
                AdvanceType = GetEnumAdvance(x.AdvanceTypeInt),
                ApprovalStatus=GetEnum(x.ApprovalStatusInt),

                Amount = x.Amount,
                DeletedTime = x.DeletedTime,
                ApprovalDate = x.ApprovalDate,
                CreatedDate = x.CreatedDate,
                Currency = GetCurrencyEnum(x.CurrencyInt),
                Description = x.Description,
                EmployeeLastName=x.Employee.LastName,
                EmployeeName=x.Employee.Name,
                UpdatedDate=x.UpdatedDate,
            }).ToList();
        }
    }
}

using Project.Application.Features.CQRS.Queries.AdvanceQueries;
using Project.Application.Features.CQRS.Results.AdvanceResults;
using Project.Application.UnitOfWork.Abstract;
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

        public async Task<List<GetAdvanceByEmployeeIdQueryResult>> Handle(GetByEmployeeIdQuery query)
        {
            var values= await unitOfWork.advanceRepository.GetAdvanceWithEmployeeWithEmployeeId(query.EmployeeId);
            return values.Select(x=> new GetAdvanceByEmployeeIdQueryResult
            {
                Id = x.Id,
                AdvanceType = x.AdvanceType,
                ApprovalStatus = x.ApprovalStatus,
                Amount = x.Amount,
                DeletedTime = x.DeletedTime,
                ApprovalDate = x.ApprovalDate,
                CreatedDate = x.CreatedDate,
                Currency = x.Currency,
                Description = x.Description,
                EmployeeLastName=x.Employee.LastName,
                EmployeeName=x.Employee.Name,
                UpdatedDate=x.UpdatedDate,
            }).ToList();
        }
    }
}

using Project.Application.Features.CQRS.Results.AdvanceResults;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.AdvanceHandlers
{
    public class GetAdvanceQueryResultHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAdvanceQueryResultHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<GetAdvanceWithEmployeeQueryResult>> Handle()
        {
            var values = unitOfWork.advanceRepository.GetAllWithEmployee();

            return values.Select(x => new GetAdvanceWithEmployeeQueryResult
            {
                Id = x.Id,
                ApprovalStatus = x.ApprovalStatus,
                AdvanceType = x.AdvanceType,
                Amount = x.Amount,
                ApprovalDate = x.ApprovalDate,
                CreatedDate = x.CreatedDate,
                Currency = x.Currency,
                DeletedTime = x.DeletedTime,
                Description = x.Description,
                EmployeeName=x.Employee.Name,
                EmployeeLastName=x.Employee.LastName,
                UpdatedDate=x.UpdatedDate,

            }).ToList();
        }
    }
}

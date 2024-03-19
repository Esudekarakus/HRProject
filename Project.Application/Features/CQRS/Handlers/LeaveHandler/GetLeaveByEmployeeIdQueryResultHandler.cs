using Project.Application.Features.CQRS.Queries.LeaveQueries;
using Project.Application.Features.CQRS.Results.LeaveResults;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.LeaveHandler
{
    public class GetLeaveByEmployeeIdQueryResultHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetLeaveByEmployeeIdQueryResultHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<GetLeaveByEmployeeIdQueryResult>> Handle(GetLeaveByEmployerIdQuery query)
        {
            var values = await unitOfWork.leaveRepository.GetLeaveWithEmployeeWithEmployeeId(query.Id);
            return values.Select(x=> new GetLeaveByEmployeeIdQueryResult
            { 
                EmployeeId = x.EmployeeId,
                Id = x.Id,
                Description = x.Description,
                DueDate = x.DueDate,
                ApprovalDate = x.ApprovalDate,
                LeaveDate = x.LeaveDate,
                NumberOfDays = x.NumberOfDays,
                EmployeeLastName=x.Employee.LastName,
                EmployeeName=x.Employee.Name,
                Type=x.Type

            }).ToList();
        }
    }
}

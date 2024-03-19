using Project.Application.Features.CQRS.Results.LeaveResults;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.LeaveHandler
{
    public class GetLeaveQueryResultHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetLeaveQueryResultHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<GetLeaveWithEmployeeQueryResult>> Handle()
        {
            var values = unitOfWork.leaveRepository.GetAllWithEmployee();
            return values.Select(x => new GetLeaveWithEmployeeQueryResult
            {
               Id= x.Id,
               EmployeeId= x.EmployeeId,
               ApprovalDate= x.ApprovalDate,
               Description= x.Description,
               DueDate= x.DueDate,
               LeaveDate= x.LeaveDate,
               EmployeeName=x.Employee.Name,
               EmployeeLastName=x.Employee.LastName,
               NumberOfDays=x.NumberOfDays,
               Type=x.Type,

            }).ToList();
        }
    }
}

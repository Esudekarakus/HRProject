using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Results.AdvanceResults
{
    public class GetAdvanceByEmployeeIdQueryResult
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }
        public AdvanceType AdvanceType { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ApprovalDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedTime { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}

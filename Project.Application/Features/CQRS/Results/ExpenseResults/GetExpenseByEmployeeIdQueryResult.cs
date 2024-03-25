using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Results.ExpenseResults
{
    public class GetExpenseByEmployeeIdQueryResult
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string InvoicePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedTime { get; set; }

        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}

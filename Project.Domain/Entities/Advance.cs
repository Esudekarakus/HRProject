using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Advance
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }
        public AdvanceType AdvanceType { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedTime { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}

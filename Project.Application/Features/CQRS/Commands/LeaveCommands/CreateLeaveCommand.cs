using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.LeaveCommands
{
    public class CreateLeaveCommand
    {
        public int Type { get; set; }
        
        public DateTime LeaveDate { get; set; }
        public DateTime DueDate { get; set; }
      
        //public DateTime? ApprovalDate { get; set; }
        public string Description { get; set; }
        public int NumberOfDays { get; set; }

        //Nav.Props.
        public int EmployeeId { get; set; }
    }
}

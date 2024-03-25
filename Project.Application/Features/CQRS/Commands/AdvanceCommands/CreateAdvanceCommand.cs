using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.AdvanceCommands
{
    public class CreateAdvanceCommand
    {
        public string Description { get; set; }
        public int Currency { get; set; }
        public int AdvanceType { get; set; }
       
        public double Amount { get; set; }
        public int EmployeeId { get; set; }
    }
}

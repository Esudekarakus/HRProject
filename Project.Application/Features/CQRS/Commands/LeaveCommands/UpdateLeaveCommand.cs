using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.LeaveCommands
{
    public class UpdateLeaveCommand
    {
        public int Id { get; set; }
        public int Status { get; set; }
        
       
        
    }
}

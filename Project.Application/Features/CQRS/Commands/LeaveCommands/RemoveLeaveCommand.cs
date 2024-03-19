using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.LeaveCommands
{
    public class RemoveLeaveCommand
    {
        public RemoveLeaveCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

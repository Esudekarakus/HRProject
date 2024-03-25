using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.AdvanceCommands
{
    public class RemoveAdvanceCommand
    {
        public RemoveAdvanceCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}

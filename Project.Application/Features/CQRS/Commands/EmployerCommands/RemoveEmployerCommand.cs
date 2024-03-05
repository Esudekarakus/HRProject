using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.EmployerCommands
{
    public class RemoveEmployerCommand
    {
        public RemoveEmployerCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}

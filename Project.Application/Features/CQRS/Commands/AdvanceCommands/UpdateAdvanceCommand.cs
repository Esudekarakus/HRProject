using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.AdvanceCommands
{
    public class UpdateAdvanceCommand
    {
        public int Id { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public ApprovalStatus ApprovalStatus { get; set; }
    }
}

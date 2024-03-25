using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.ExpenseCommands
{
    public class UpdateExpenseCommand
    {
        public int Id { get; set; }
        public int ApprovalStatus { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}

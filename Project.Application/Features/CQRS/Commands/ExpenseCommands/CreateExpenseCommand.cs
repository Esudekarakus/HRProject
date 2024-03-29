using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.ExpenseCommands
{
    public class CreateExpenseCommand
    {
        public string Description { get; set; }
        public int Currency { get; set; }
        public int ExpenseType { get; set; }
        public string InvoicePath { get; set; }
        public double Amount { get; set; }
        public int? EmployeeId { get; set; }
        public string? FileName { get; set; }
        public IFormFile? FormFile { get; set; }
    }
}

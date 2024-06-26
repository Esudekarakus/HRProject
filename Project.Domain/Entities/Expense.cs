﻿using Microsoft.AspNetCore.Http;
using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Expense 
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int  Currency { get; set; }
        public int ExpenseType { get; set; }
        public int ApprovalStatus { get; set; }
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string InvoicePath { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime? ApprovalDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedTime { get; set; }

        [NotMapped] 
        public IFormFile? ExpenseFile { get; set; }
        [NotMapped]
        public string FileSrc { get; set; }
        public string? FileName { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}

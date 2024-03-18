﻿using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class DayOff
    {
        public int Id { get; set; }
        public DayOffType Type { get; set; }
        public ApprovalStatus Status { get; set; }
        public DateTime LeaveDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string Description { get; set; }
        public int NumberOfDays { get; set; }

        //Nav.Props.
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
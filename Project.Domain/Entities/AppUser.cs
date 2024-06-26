﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? EmployeeID { get; set; }
        public Employee? Employee { get; set; }
        public int? EmployerID { get; set; }
        public Employer? Employer { get; set; }
    }
}

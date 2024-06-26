﻿using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Entities
{
    public class Employee : BaseEntity
    {

        public Employee()
        {
            Expenses = new List<Expense>();
            Advances = new List<Advance>();
            Leaves = new List<Leave>();
        }

        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthOfPlace { get; set; }

        [StringLength(11)]
        public string IdendificationNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public string Department { get; set; }
        public int Status { get; set; }
        public string? ImageName { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        [NotMapped]
        public string ImageSrc { get; set; }
        public string Address { get; set; }
        public string PrivateMail { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public string Email
        {
            get
            {
               
                string email = $"{LastName?.ToLower()}{Name.ToLower()}@bilgeadam.boost";
                return email;
            }
        }
        public double Salary { get; set; }
        public int? OffDays { get; set; }
        public string Profession { get; set; }

        public List<Expense> Expenses { get; set; }
        public List<Advance> Advances { get; set; }
        public List<Leave> Leaves { get; set; }

    }
}

using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Enum;

namespace Project.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string FirstName2 { get; set; }
        public string LastName { get; set; }
        public string LastName2 { get; set; }
        public string BirthOfPlace { get; set; }
        public string IdendificationNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }
        public string ImageURL { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public int? OffDays { get; set; }
        public string Profession { get; set; }
    }
}

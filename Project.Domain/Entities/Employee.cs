using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Entities
{
    public class Employee : BaseEntity
    {
       
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthOfPlace { get; set; }

        [StringLength(11)]
        public string IdendificationNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public string Department { get; set; }
        public Status Status { get; set; }
        public string ImageName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string Address { get; set; }
        public string PrivateMail { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        public string Email
        {
            get
            {
                string birthYear = DateOfBirth.Year.ToString();
                string email = $"{LastName?.ToLower()}{birthYear}@bilgeadam.boost";
                return email;
            }
        }
        public double Salary { get; set; }
        public int? OffDays { get; set; }
        public string Profession { get; set; }
    }
}

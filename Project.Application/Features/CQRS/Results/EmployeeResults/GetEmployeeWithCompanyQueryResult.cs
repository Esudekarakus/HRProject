using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Results.EmployeeResults
{
    public class GetEmployeeWithCompanyQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string BirthOfPlace { get; set; }

        public string CompanyName { get; set; }

        public string IdendificationNumber { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public int? CompanyId { get; set; }

        public string Department { get; set; }
        public Status Status { get; set; }
        public string ImageURL { get; set; }




        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public double Salary { get; set; }
        public int? OffDays { get; set; }
        public string Profession { get; set; }
    }
}

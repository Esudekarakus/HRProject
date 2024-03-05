using Project.Domain.Entities;
using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Results.EmployerResult
{
    public class GetEmployerByIdQueryResult
    {
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string SecondLastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public Status Status { get; set; }

        public string ImagePath { get; set; }
        public string Address { get; set; }


        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        public string Profession { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfEnd { get; set; }
        public Company? Company { get; set; }
        public int? OffDays { get; set; }
        public int? CompanyId { get; set; }

        public string Email { get; set; }
    }
}

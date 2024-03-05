using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Employer:BaseEntity
    {
       public string LastName { get; set; }
       public string SecondName { get; set; }
       public string SecondLastName {get; set; }

       public DateTime DateOfBirth { get; set; }
       public Status Status { get; set; }

       public string ImagePath { get; set; }
       public string Address {  get; set; }

       public string Telephone { get; set; }
       public double Salary { get; set; }
       public string Profession {  get; set; }
        
       public Company? Company { get; set; }
       public int? CompanyId { get; set; }

       public string Email
        {
            get
            {
                string birthYear = DateOfBirth.Year.ToString();
                string email=$"{LastName?.ToLower()}{birthYear}@bilgeadam.boost";
                return email;
            }
        }
    }
}

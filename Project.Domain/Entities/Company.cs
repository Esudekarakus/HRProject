using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Employees = new List<Employee>();
            Employers = new List<Employer>();
        }
        public DateTime FoundationDate { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string VatNumber { get; set; }

        public List<Employee> Employees { get; set; }
        public List<Employer> Employers { get; set; }

      

    }
}

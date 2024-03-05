using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string LastName { get; set; }
        public int Salary { get; set; }
        public OffDay OffDay { get; set; }
    }
}

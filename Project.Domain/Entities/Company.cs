using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Domain.Entities
{
    public class Company : BaseEntity
    {
        public DateTime FoundationDate { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }

        public int VatNumber { get; set; }


    }
}

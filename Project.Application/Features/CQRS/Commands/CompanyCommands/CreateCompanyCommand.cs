using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.CompanyCommands
{
    public class CreateCompanyCommand
    {
        public DateTime FoundationDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int VatNumber { get; set; }
    }
}

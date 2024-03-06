using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Results.CompanyResult
{
    public class GetCompanyByIdQueryResult
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int VatNumber { get; set; }
    }
}

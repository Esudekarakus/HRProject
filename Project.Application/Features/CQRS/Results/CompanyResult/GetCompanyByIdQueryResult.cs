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

        public string VatNumber { get; set; }
        public string TaxOffice { get; set; }
        public string? MersisNo { get; set; }
        public string? Email { get; set; }
        public string? ImageURL  { get; set; }
       public DateTime? DateOfContractStart { get; set; }
        public DateTime? DateOFContractEnd { get; set; }
        public int? Status { get; set; }
        public int? NumberOfEmployees { get; set; }
        public int? NumberOfEmployers { get; set; }
    }
}

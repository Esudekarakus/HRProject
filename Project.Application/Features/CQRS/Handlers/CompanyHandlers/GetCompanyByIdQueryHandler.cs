using Project.Application.Features.CQRS.Queries.CompanQueries;
using Project.Application.Features.CQRS.Results.CompanyResult;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.CompanyHandlers
{
    public class GetCompanyByIdQueryHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompanyByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<GetCompanyByIdQueryResult> Handle(GetCompanyByIdQuery query)
        {
            var values = await unitOfWork.companyRepository.GetByIdAsync(query.Id);

            return new GetCompanyByIdQueryResult
            {
                Id = values.Id,
                Address = values.Address,
                FoundationDate = values.FoundationDate,
                Name = values.Name,
                PhoneNumber = values.PhoneNumber,
                VatNumber = values.VatNumber,
                Email=values.Email,
                TaxOffice=values.TaxOffice,
                MersisNo=values.MersisNo,
                ImageURL=values.ImageURL,
                Status=values.Status,
                DateOFContractEnd=values.DateOFContractEnd,
                DateOfContractStart=values.DateOfContractStart
            };
        }
    }
}

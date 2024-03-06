using Project.Application.Features.CQRS.Results.CompanyResult;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.CompanyHandlers
{
    public class GetCompanyQueryHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetCompanyQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<GetCompanyQueryResult>> Handle()
        {
            var values= await unitOfWork.companyRepository.GetAllAsync();

            return values.Select(x=> new GetCompanyQueryResult
            {
                Id = x.Id,
                Address = x.Address,
                FoundationDate = x.FoundationDate,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                VatNumber = x.VatNumber,
            }).ToList();    
        }
    }
}

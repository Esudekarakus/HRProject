using Project.Application.Features.CQRS.Queries.EmployerQueries;
using Project.Application.Features.CQRS.Results.EmployerResults;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployerHandlers
{
    public class GetEmployerByIdWithCompanyQueryHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetEmployerByIdWithCompanyQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => unitOfWork;

        public async Task<GetEmployerByIdWithCompanyQueryResult> Handle(GetEmployerByIdWithCompanyQuery query)
        {
            var values= await unitOfWork.employerRepository.GetEmployerByIdWithCompanyAsync(query.Id);

            return new GetEmployerByIdWithCompanyQueryResult
            {
               Id = values.Id,
               Salary = values.Salary,
               SecondLastName = values.LastName,
               SecondName = values.LastName,
               Address = values.Address,    
               Status = values.Status,
               DateOfStart = values.DateOfStart,
               CompanyId = values.CompanyId,
               CompanyName=values.Company.Name,
               DateOfBirth = values.DateOfBirth,
               DateOfEnd = values.DateOfEnd,
               Department=values.Department,
               Email=values.Email,
               IdentityNumber=values.IdentityNumber,
               ImagePath=values.ImagePath,
               LastName=values.LastName,
               Name=values.Name,
               OffDays=values.OffDays,
               PhoneNumber=values.PhoneNumber,
               PlaceOfBirth=values.PlaceOfBirth,
               Profession=values.Profession,


            };
        }

    }
}

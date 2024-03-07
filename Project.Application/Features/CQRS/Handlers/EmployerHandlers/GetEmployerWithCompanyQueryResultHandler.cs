using Project.Application.Features.CQRS.Results.EmployerResults;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployerHandlers
{
    public class GetEmployerWithCompanyQueryResultHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetEmployerWithCompanyQueryResultHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        public  List<GetEmployerWithCompanyQueryResult> Handle() 
        {
            var values = unitOfWork.employerRepository.GetEmployersWithCompany();
            return values.Select(x=> new GetEmployerWithCompanyQueryResult
            {
                DateOfBirth = x.DateOfBirth,
                DateOfEnd = x.DateOfEnd,
                Salary = x.Salary,
                SecondLastName = x.SecondLastName,
                SecondName = x.SecondName,
                Status = x.Status,
                DateOfStart = x.DateOfStart,
                OffDays = x.OffDays,
                Address = x.Address,
                CompanyId = x.CompanyId,
                CompanyName=x.Company.Name,
                Email=x.Email,
                Id = x.Id,
                IdentityNumber = x.IdentityNumber,
                ImagePath = x.ImagePath,
                LastName = x.LastName,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                PlaceOfBirth = x.PlaceOfBirth,
                Profession=x.Profession
                
            }).ToList();
        }
    }
}

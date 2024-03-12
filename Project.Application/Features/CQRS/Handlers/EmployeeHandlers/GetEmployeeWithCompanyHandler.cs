using Project.Application.Features.CQRS.Results.EmployeeResults;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployeeHandlers
{
    public class GetEmployeeWithCompanyHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetEmployeeWithCompanyHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        

        public List<GetEmployeeWithCompanyQueryResult> Handle()
        {
            var values = unitOfWork.employeeRepository.GetEmployeesWithCompany();

            return values.Select(x=> new GetEmployeeWithCompanyQueryResult
            {
                Name = x.Name,
                MiddleName = x.MiddleName,
                LastName = x.LastName,
                BirthOfPlace = x.BirthOfPlace,
                Salary = x.Salary,
                SecondLastName = x.SecondLastName,
                Status = x.Status,
                DateOfStart = x.DateOfStart,
                CompanyId = x.CompanyId,
                CompanyName=x.Company.Name,
                DateOfBirth=x.DateOfBirth,
                DateOfEnd=x.DateOfEnd,
                Department=x.Department,
                OffDays=x.OffDays,
                Email=x.Email,
                Id=x.Id,
                IdendificationNumber=x.IdendificationNumber,
                ImageURL=x.ImageURL,
                PhoneNumber=x.PhoneNumber,
                Profession=x.Profession
                
            }).ToList();
        }
    }
}

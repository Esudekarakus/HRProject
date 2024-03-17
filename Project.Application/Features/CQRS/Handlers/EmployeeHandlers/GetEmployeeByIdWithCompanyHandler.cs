using Project.Application.Features.CQRS.Queries.EmployeeQueries;
using Project.Application.Features.CQRS.Results.EmployeeResults;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployeeHandlers
{
    public class GetEmployeeByIdWithCompanyHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetEmployeeByIdWithCompanyHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

       
        public async Task<GetEmployeeByIdWithCompanyQueryResult> Handle(GetEmployeeByIdWithCompanyQuery query)
        {
            var values = await unitOfWork.employeeRepository.GetEmployeeByIdWithCompanyAsync(query.Id);

            return new GetEmployeeByIdWithCompanyQueryResult
            {
                Id = values.Id,
                Salary = values.Salary,
                SecondLastName = values.SecondLastName,
                Name = values.Name,
                BirthOfPlace = values.BirthOfPlace,
                Status = values.Status,
                DateOfStart = values.DateOfStart,
                CompanyId = values.CompanyId,
                CompanyName=values.Company.Name,
                DateOfBirth=values.DateOfBirth,
                DateOfEnd=values.DateOfEnd,
                Department=values.Department,
                Email=values.Email,
                IdendificationNumber=values.IdendificationNumber,
               
                LastName=values.LastName,
                MiddleName=values.MiddleName,
                OffDays=values.OffDays,
                PhoneNumber=values.PhoneNumber,
                Profession=values.Profession,

            };

        }
    }
}

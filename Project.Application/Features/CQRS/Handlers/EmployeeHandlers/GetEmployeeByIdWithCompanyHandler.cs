using Project.Application.Features.CQRS.Queries.EmployeeQueries;
using Project.Application.Features.CQRS.Results.EmployeeResults;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Enum;
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

        public Status GetEnumStatus(int status)
        {
            switch (status)
            {
                case 1:
                    return Status.Active;
                case 2:
                    return Status.Passive;
                default:
                    return Status.Passive;
            }
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
                Status = GetEnumStatus(values.Status),
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

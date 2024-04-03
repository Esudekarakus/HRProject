using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public class GetEmployeeWithCompanyHandler
    {
        private readonly IUnitOfWork unitOfWork;

        public GetEmployeeWithCompanyHandler(IUnitOfWork unitOfWork)
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

        public List<GetEmployeeWithCompanyQueryResult> Handle()
        {
            var employees = unitOfWork.employeeRepository.GetEmployeesWithCompany();
            var results= new List<GetEmployeeWithCompanyQueryResult>();

            foreach (var employee in employees)
            {
                var statusE= GetEnumStatus(employee.Status);

                results.Add(new GetEmployeeWithCompanyQueryResult
                {
                    Id = employee.Id,
                    Status = statusE,
                    Name = employee.Name,
                    MiddleName = employee.MiddleName,
                    Salary = employee.Salary,
                    SecondLastName = employee.LastName,
                    DateOfStart = employee.DateOfStart,
                    BirthOfPlace = employee.BirthOfPlace,
                    CompanyId = employee.CompanyId,
                    CompanyName = employee.Company.Name,
                    DateOfBirth = employee.DateOfBirth,
                    DateOfEnd = employee.DateOfEnd,
                    Department = employee.Department,
                    Email = employee.Email,
                    IdendificationNumber = employee.IdendificationNumber,
                    LastName = employee.LastName,
                    OffDays = employee.OffDays,
                    ImageName=employee.ImageName,
                    ImageSrc = employee.ImageSrc,


                PhoneNumber = employee.PhoneNumber,
                    Profession = employee.Profession,

                });
               
            }
            return results;

        }
    }
}

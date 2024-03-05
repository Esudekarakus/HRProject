using Project.Application.Features.CQRS.Results.EmployerResults;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployerQueries
{
    public class GetEmployerByIdQueryHandler
    {
        private readonly IRepository<Employer> repository;

        public  GetEmployerByIdQueryHandler(IRepository<Employer> repository)
        {
            this.repository = repository;
        }

        public async Task<GetEmployerByIdQueryResult> Handle(GetEmployerByIdQueryResult result)
        {
            var values = await repository.GetByIdAsync(result.Id);
            return new GetEmployerByIdQueryResult
            {
                LastName = result.LastName,
                Salary = result.Salary,
                Address = result.Address,
                ImagePath = result.ImagePath,
                Company = result.Company,
                Profession = result.Profession,
                OffDays = result.OffDays,
                SecondLastName = result.SecondLastName,
                DateOfBirth = result.DateOfBirth,
                DateOfEnd = result.DateOfEnd,
                DateOfStart = result.DateOfStart,
                PhoneNumber = result.PhoneNumber,
                CompanyId = result.CompanyId,
            };
        }
    }
}

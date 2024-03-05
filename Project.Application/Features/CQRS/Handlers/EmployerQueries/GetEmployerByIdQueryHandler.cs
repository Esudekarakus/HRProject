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

        public async Task<GetEmployerByIdQueryResult> Handle(GetEmployerByIdQuery query)
        {
            var values = await repository.GetByIdAsync(query.Id);
            return new GetEmployerByIdQueryResult
            {
                LastName = query.LastName,
                Salary = query.Salary,
                Address = query.Address,
                ImagePath = query.ImagePath,
                Company = query.Company,
                Profession =query.Profession,
                OffDays = query.OffDays,
                SecondLastName = query.SecondLastName,
                DateOfBirth = query.DateOfBirth,
                DateOfEnd = query.DateOfEnd,
                DateOfStart = query.DateOfStart,
                PhoneNumber = query.PhoneNumber,
                CompanyId = query.CompanyId,
            };
        }
    }
}

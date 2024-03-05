using Project.Application.Features.CQRS.Queries.EmployerQueries;
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
                Address = values.Address,
                Salary = values.Salary,
                SecondLastName = values.LastName,
                SecondName = values.Name,
                Status = values.Status,
                DateOfStart = values.DateOfStart,
                DateOfBirth = values.DateOfBirth,
                DateOfEnd = values.DateOfEnd,
                ImagePath = values.ImagePath,
                LastName = values.LastName,
                IdentityNumber = values.IdentityNumber,
                PlaceOfBirth = values.PlaceOfBirth,
                Id = values.Id,
                Email = values.Email,
                OffDays = values.OffDays,
                PhoneNumber = values.PhoneNumber,
                Profession = values.Profession
            };
        }
    }
}

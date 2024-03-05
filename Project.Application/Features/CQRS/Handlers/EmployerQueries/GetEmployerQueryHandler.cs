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
    public class GetEmployerQueryHandler
    {
        private readonly IRepository<Employer> repository;

        public GetEmployerQueryHandler(IRepository<Employer> repo)
        {
            repository = repo;
        }

        public async Task<List<GetEmployerQueryResult>> Handle()
        {
            var values = await repository.GetAllAsync();
            return values.Select(x => new GetEmployerQueryResult
            {
                LastName = x.LastName,
                SecondLastName = x.LastName,
                PhoneNumber = x.PhoneNumber,
                SecondName = x.LastName,
                Status = x.Status,
                ImagePath = x.ImagePath,
                Address = x.Address,
                Salary = x.Salary,
                DateOfBirth = x.DateOfBirth,
                DateOfStart=x.DateOfStart,
                DateOfEnd=x.DateOfEnd,
                IdentityNumber = x.IdentityNumber,
                PlaceOfBirth = x.PlaceOfBirth,
               
                Profession=x.Profession,
                CompanyId=x.CompanyId,
                OffDays=x.OffDays,
                Email=x.Email,
                Company=x.Company,

            }).ToList();
        }
    }
}

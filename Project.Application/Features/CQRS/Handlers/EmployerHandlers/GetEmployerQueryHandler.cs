using Project.Application.Features.CQRS.Results.EmployerResults;
using Project.Application.Repositories.Abstract;
using Project.Application.UnitOfWork.Abstract;
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
        private readonly IUnitOfWork unitOfWork;

        public GetEmployerQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<GetEmployerQueryResult>> Handle()
        {
            var values = await unitOfWork.employerRepository.GetAllAsync();
            return values.Select(x => new GetEmployerQueryResult
            {
                Id = x.Id,
                Name = x.Name,
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
                Email=x.Email
               

            }).ToList();
        }
    }
}

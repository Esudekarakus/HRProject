using Project.Application.Features.CQRS.Queries.EmployerQueries;
using Project.Application.Features.CQRS.Results.EmployerResults;
using Project.Application.UnitOfWork.Abstract;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployerQueries
{
    public class GetEmployerByIdQueryHandler
    {
        private readonly IUnitOfWork unitOfWork;

       

        public GetEmployerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork => unitOfWork;

        public async Task<GetEmployerByIdQueryResult> Handle(GetEmployerByIdQuery query)
        {
            var values = await unitOfWork.employerRepository.GetByIdAsync(query.Id);
            return new GetEmployerByIdQueryResult
            {
                Id = values.Id,
                Name = values.Name,
                LastName = values.LastName,
                SecondLastName = values.LastName,
                PhoneNumber = values.PhoneNumber,
                SecondName = values.LastName,
                Status = values.Status,
                ImagePath = values.ImagePath,
                Address = values.Address,
                Salary = values.Salary,
                DateOfBirth = values.DateOfBirth,
                DateOfStart = values.DateOfStart,
                DateOfEnd = values.DateOfEnd,
                IdentityNumber = values.IdentityNumber,
                PlaceOfBirth = values.PlaceOfBirth,
                Department = values.Department,
                Profession = values.Profession,
                CompanyId = values.CompanyId,
                OffDays = values.OffDays,
                Email = values.Email


            };
        }
    }
}

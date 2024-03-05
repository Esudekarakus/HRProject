﻿using Project.Application.Features.CQRS.Queries.EmployerQueries;
using Project.Application.Features.CQRS.Results.EmployerResults;
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

            };
        }
    }
}

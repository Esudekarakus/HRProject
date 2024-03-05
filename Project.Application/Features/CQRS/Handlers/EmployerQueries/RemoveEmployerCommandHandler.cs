using Project.Application.Features.CQRS.Commands.EmployerCommands;
using Project.Application.Interfaces;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Handlers.EmployerQueries
{
    public class RemoveEmployerCommandHandler
    {
        private readonly IRepository<Employer> repository;
        public RemoveEmployerCommandHandler(IRepository<Employer> repo) 
        {
            repository = repo;
        }

        public async Task Handle(RemoveEmployerCommand removeCommand)
        {
            var value = await repository.GetByIdAsync(removeCommand.Id);
            await repository.RemoveAsync(value);
        }
    }
}

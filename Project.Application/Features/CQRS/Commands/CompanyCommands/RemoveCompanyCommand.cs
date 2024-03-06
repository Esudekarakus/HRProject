using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Commands.CompanyCommands
{
    public class RemoveCompanyCommand
    {
        public RemoveCompanyCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
}

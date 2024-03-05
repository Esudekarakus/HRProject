using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Queries.EmployerQueries
{
    public class GetEmployerByIdQuery
    {
        public int Id { get; set; }

        public GetEmployerByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}

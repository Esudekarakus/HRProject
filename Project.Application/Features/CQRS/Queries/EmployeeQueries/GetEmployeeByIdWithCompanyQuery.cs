using Project.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Queries.EmployeeQueries
{
    public class GetEmployeeByIdWithCompanyQuery
    {
        public GetEmployeeByIdWithCompanyQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Queries.AdvanceQueries
{
    public class GetByEmployeeIdQuery
    {
        public int EmployeeId { get; set; } 
        public GetByEmployeeIdQuery(int id) 
        { 
            EmployeeId = id;

        }
    }
}

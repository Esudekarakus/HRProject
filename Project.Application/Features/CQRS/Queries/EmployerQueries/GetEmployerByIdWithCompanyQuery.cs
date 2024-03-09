using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Queries.EmployerQueries
{
    public class GetEmployerByIdWithCompanyQuery
    {
        public GetEmployerByIdWithCompanyQuery(int id)
        {
            Id = id;
            
        }

        public int Id { get; set; }
       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Queries.CompanQueries
{
    public class GetCompanyByIdQuery
    {
        public int Id { get; set; }

        public GetCompanyByIdQuery(int id) 
        {
            Id = id;
        }
    }
}

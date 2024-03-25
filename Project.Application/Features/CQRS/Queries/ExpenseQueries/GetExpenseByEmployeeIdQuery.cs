using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Features.CQRS.Queries.ExpenseQueries
{
    public class GetExpenseByEmployeeIdQuery
    {
        public GetExpenseByEmployeeIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

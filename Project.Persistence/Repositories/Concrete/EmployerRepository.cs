using Microsoft.EntityFrameworkCore;
using Project.Application.Repositories.Abstract;
using Project.Domain.Entities;
using Project.Persistence.Context;
using Project.Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence.Repositories.Concrete
{
    public class EmployerRepository : GenericRepository<Employer>, IEmployerRepository
    {
        protected readonly AppDbContext Context;

        public EmployerRepository(AppDbContext Context) : base(Context)
        {
            this.Context = Context;
        }


    }
}

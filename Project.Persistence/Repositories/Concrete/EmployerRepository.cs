using Microsoft.EntityFrameworkCore;
using Project.Application.Repositories.Abstract;
using Project.Domain.Entities;
using Project.Persistence.Context;

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

        public async Task<Employer> GetEmployerByIdWithCompanyAsync(int employerId)
        {
            return await Context.Employers.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == employerId);
        }

        public List<Employer> GetEmployersWithCompany()
        {
            return Context.Employers.Include(x => x.Company).ToList();
        }

        
    }
}

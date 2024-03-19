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
    public class AdvanceRepository : GenericRepository<Advance>, IAdvanceRepository
    {
        private readonly AppDbContext context;

        public AdvanceRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Advance>> GetAdvanceWithEmployeeWithEmployeeId(int employeeId)
        {
            return await context.Advances.Include(x=>x.Employee).Where(x=>x.EmployeeId == employeeId).ToListAsync();
        }

        public List<Advance> GetAllWithEmployee()
        {
            return context.Advances.Include(x => x.Employee).ToList();
        }

        
    }
}

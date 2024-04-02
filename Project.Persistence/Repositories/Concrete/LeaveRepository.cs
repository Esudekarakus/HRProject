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
    public class LeaveRepository : GenericRepository<Leave>, ILeaveRepository
    {
        private readonly AppDbContext context;

        public LeaveRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<Leave> GetAllWithEmployee()
        {
            return context.Leaves.Include(x=>x.Employee).ToList();
        }

        public async Task<List<Leave>> GetLeaveWithEmployeeByCompanyId(int companyId)
        {
            return await context.Leaves.Include(x=>x.Employee).Where(x=>x.Employee.CompanyId == companyId).ToListAsync();   
        }

        public async Task<List<Leave>> GetLeaveWithEmployeeWithEmployeeId(int employeeId)
        {
            return await context.Leaves.Include(x=>x.Employee).Where(x=>x.EmployeeId == employeeId).ToListAsync();
        }
    }
}

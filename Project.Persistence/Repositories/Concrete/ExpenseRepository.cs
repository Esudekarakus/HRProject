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
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        private readonly AppDbContext _context;

        public ExpenseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Expense>> GetExpenseWithEmployeeByEmployeeId(int employeeId)
        {
            return await _context.Expenses.Include(x=>x.Employee).Where(x=>x.EmployeeId == employeeId).ToListAsync();   
        }

        public List<Expense> GetAllWithEmployee()
        {
            return _context.Expenses.Include(x=>x.Employee).ToList();
        }

        public Task<List<Expense>> GetExpenseWithEmployeeByCompanyId(int companyId)
        {
           return _context.Expenses.Include(x=>x.Employee).Where(x=>x.Employee.CompanyId== companyId).ToListAsync();    
        }
    }
}

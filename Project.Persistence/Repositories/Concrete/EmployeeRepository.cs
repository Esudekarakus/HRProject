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
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        protected readonly AppDbContext _Context;
        public EmployeeRepository(AppDbContext Context) : base(Context)
        {
            this._Context = Context;
        }

        public async Task<Employee> GetEmployeeByIdWithCompanyAsync(int employeeId)
        {
            return await _Context.Employees.Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == employeeId);
        }

        public List<Employee> GetEmployeesWithCompany()
        {
            return _Context.Employees.Include(x=>x.Company).ToList();    
        }

        public double GetSalaryByEmployeeId(int employeeId)
        {
            var employee= _Context.Employees.FirstOrDefault(x=>x.Id == employeeId);

            return employee.Salary;
        }
    }
}

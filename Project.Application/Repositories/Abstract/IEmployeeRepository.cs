using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories.Abstract
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        List<Employee> GetEmployeesWithCompany();

        Task<Employee> GetEmployeeByIdWithCompanyAsync(int employeeId);

        public double GetSalaryByEmployeeId(int employeeId);

    }
}

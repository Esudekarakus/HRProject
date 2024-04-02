using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories.Abstract
{
    public interface IExpenseRepository:IRepository<Expense>
    {
        List<Expense> GetAllWithEmployee();
        Task<List<Expense>> GetExpenseWithEmployeeByEmployeeId(int employeeId);
        Task<List<Expense>> GetExpenseWithEmployeeByCompanyId(int companyId);
    }
}

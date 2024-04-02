using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories.Abstract
{
    public interface IAdvanceRepository:IRepository<Advance>
    {
        List<Advance> GetAllWithEmployee();
        Task<List<Advance>> GetAdvanceWithEmployeeWithEmployeeId(int employeeId);
        Task<List<Advance>> GetAdvanceWithEmployeeByCompanyId(int companyId);
    }
}

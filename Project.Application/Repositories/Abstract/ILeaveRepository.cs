using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories.Abstract
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        List<Leave> GetAllWithEmployee();
        Task<List<Leave>> GetLeaveWithEmployeeWithEmployeeId(int employeeId);
    }
}

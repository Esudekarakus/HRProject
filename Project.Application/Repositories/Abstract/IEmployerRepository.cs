using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Repositories.Abstract
{
    public interface IEmployerRepository : IRepository<Employer>
    {
      List<Employer> GetEmployersWithCompany();
    }
}

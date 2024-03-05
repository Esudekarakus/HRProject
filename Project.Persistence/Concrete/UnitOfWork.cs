using Project.Application.Repositories.Abstract;
using Project.Application.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {


        public UnitOfWork()
        {
            
        }

        public IEmployerRepository experienceRepository => throw new NotImplementedException();

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

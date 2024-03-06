using Project.Application.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.Application.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployerRepository employerRepository { get; }
        ICompanyRepository companyRepository { get; }

        Task<int> CommitAsync();
        void Dispose();

    }
}

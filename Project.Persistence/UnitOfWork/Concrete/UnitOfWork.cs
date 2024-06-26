﻿using Project.Application.Repositories.Abstract;
using Project.Application.UnitOfWork.Abstract;
using Project.Persistence.Context;
using Project.Persistence.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private EmployerRepository EmployerRepository;
        private CompanyRepository CompanyRepository;
        private EmployeeRepository EmployeeRepository;
        private AdvanceRepository AdvanceRepository;
        private LeaveRepository LeaveRepository;
        private ExpenseRepository ExpenseRepository;

        public UnitOfWork(AppDbContext _context)
        {
            this._context = _context;
        }

        public IEmployerRepository employerRepository => EmployerRepository ?? new EmployerRepository(_context);
        public ICompanyRepository companyRepository => CompanyRepository ?? new CompanyRepository(_context);
        public IEmployeeRepository employeeRepository => EmployeeRepository ?? new EmployeeRepository(_context);

        public IAdvanceRepository advanceRepository => AdvanceRepository ?? new AdvanceRepository(_context);
        public ILeaveRepository leaveRepository => LeaveRepository ?? new LeaveRepository(_context);

        public IExpenseRepository expenseRepository => ExpenseRepository ?? new ExpenseRepository(_context);
        

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}

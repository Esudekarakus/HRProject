﻿using Project.Application.Repositories.Abstract;
using Project.Domain.Entities;
using Project.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence.Repositories.Concrete
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        protected readonly AppDbContext appDbContext;
        public CompanyRepository(AppDbContext context) : base(context)
        {
            this.appDbContext = context;
        }
    }
}

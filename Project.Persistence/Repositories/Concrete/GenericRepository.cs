﻿using Microsoft.EntityFrameworkCore;
using Project.Application.Repositories.Abstract;
using Project.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Persistence.Repositories.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;

        public GenericRepository(AppDbContext context)
        {
            context = context;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
            await context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
           
        }

        public async Task RemoveAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Project.Core.Models.Common;
using Project.DAL.Contexts;
using Project.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task CreateAsync(T entity)
        {
          await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
           Table.Remove(entity);
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
          return await Table.ToListAsync();
        }

        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();
            return query =  query.Where(condition);
            
           
        }

        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
           T? result = await Table.FirstOrDefaultAsync(x => x.Id == id);
            return result;

        }

        public async Task<T> GetSingleByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> query = Table.AsQueryable();
            
            T? entity = await query.SingleOrDefaultAsync(condition);

            return entity;

        }

        public async Task<bool> IsExistAsync(int id)
        {
           return await  Table.AnyAsync(x => x.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
           int rows = await _context.SaveChangesAsync();
            return rows;
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}

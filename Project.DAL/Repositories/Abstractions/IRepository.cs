using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Project.Core.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Abstractions
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table {  get; }
        Task CreateAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<ICollection<T>> GetAllAsync();        
        Task<T> GetByIdAsync(int id, params string[] includes);
        Task<int> SaveChangesAsync();
        IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition);
        IQueryable<T> GetSingleByCondition(Expression<Func<T, bool>> condition);
        Task IsExistAsync(int id);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tusk.Application
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> All();
        Task<T> FindAsync(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task<T> DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }

}
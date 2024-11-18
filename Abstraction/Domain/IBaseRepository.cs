using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Domain
{
    public interface IBaseRepository<TSource> where TSource : class
    {
        Task<TSource> GetByIdAsync(Guid id, bool noTraking = true);
        Task<TSource> GetFirstAsync(Expression<Func<TSource, bool>> predicate = null, bool noTracking = true);
        IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> predicate, bool noTracking = true);
        IQueryable<TResult> GetAll<TResult>(Expression<Func<TSource, TResult>> selector, Expression<Func<TSource, bool>> predicate = null, Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null, bool noTraking = true);
        Task<bool> CreateAsync(TSource TEntity);
        Task<bool> UpdateAsync(TSource TEntity);
        Task<bool> DeleteAsync(Guid id);
        Task<int> CommitAsync();

    }
}

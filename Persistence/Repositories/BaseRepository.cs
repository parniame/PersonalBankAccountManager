using Abstraction.Domain;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BaseRepository<TSource> : IBaseRepository<TSource> where TSource : BaseEntity 
    {
        private readonly PersonalBankAccountManagerDBContext _dbcontext;
        private readonly DbSet<TSource> _entitySet;
        public BaseRepository(PersonalBankAccountManagerDBContext dbcontext)
        {
            _dbcontext = dbcontext;
            _entitySet = _dbcontext.Set<TSource>();

        }
        public IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> predicate = null, bool noTraking = true)
        {
            var query = _entitySet.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return noTraking ? query.AsNoTracking() : query;

        }
        public IQueryable<TResult> GetAll<TResult>(Expression<Func<TSource, TResult>> selector, Expression<Func<TSource, bool>> predicate = null, Func<IQueryable<TSource>, IIncludableQueryable<TSource, object>> include = null, bool noTracking = true)
        {
            IQueryable<TSource> query = noTracking ? _entitySet.AsNoTracking() : _entitySet.AsQueryable();
            query = predicate == null ? query : query.Where(predicate);
            query = include == null ? query : include(query);
            return query.Select<TSource, TResult>(selector);
        }
        public async Task<TSource> GetByIdAsync(Guid id, bool noTracking = true)
        {
            var tSource = await _entitySet.FindAsync(id);
            if (noTracking)
                _dbcontext.Entry(tSource).State = EntityState.Detached;
            return tSource;
        }
        public async Task<TSource> GetFirstAsync(Expression<Func<TSource, bool>> predicate, bool noTracking = true)
        {
            var tSource = await Task.Run(() => _entitySet.FirstOrDefault(predicate));
            if (noTracking) _dbcontext.Entry(tSource).State = EntityState.Detached;
            return tSource;
        }
        public async Task<bool> CreateAsync(TSource TEntity)
        {
            await _entitySet.AddAsync(TEntity);
            await CommitAsync();

            return true;

        }
        public async Task<bool> UpdateAsync(TSource TEntity)
        {
            _entitySet.Update(TEntity);
            await CommitAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var tSource = await GetByIdAsync(id);
            _entitySet.Remove(tSource);
            await CommitAsync();

            return true;

        }
        public async Task<int> CommitAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }

    }
}

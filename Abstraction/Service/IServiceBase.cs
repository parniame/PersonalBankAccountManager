using Abstraction.Domain;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Service
{
    public interface IServiceBase<Entity, DTO> where Entity : BaseEntity where DTO : BaseDTO
    {
        Entity MapToEntity(DTO dto);
        DTO MapToDTO(Entity entity);
        Task<DTO> GetByIdAsync(Guid Id, bool readOnly = true);
        Task<DTO> GetAsync(Expression<Func<Entity, bool>> predicate = null, bool readOnly = true);
        Task<IList<DTO>> GetAllAsync(Expression<Func<Entity, bool>> predicate = null);
        Task<IList<TDTO>> GetAllAsync<TResult, TDTO>(Expression<Func<Entity, TResult>> selector,
            Expression<Func<Entity, bool>> predicate = null,
            Func<IQueryable<Entity>,
            IIncludableQueryable<Entity, object>> include = null,
            bool noTraking = true);
        Task<bool> CreateAsync(DTO dto);
        Task<bool> UpdateAsync(DTO dto);
        Task<bool> DeleteAsync(Guid Id);
    }
}

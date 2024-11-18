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
    public interface IServiceBase<Entity> where Entity : BaseEntity 
    {
        Entity MapToEntity<DtO>(DtO dto);
        DtO MapToDTO<DtO>(Entity entity);
        TResult MapToCustom<TSource, TResult>(TSource source);
        //Task<DTO> GetByIdAsync<DTO>(Guid Id, bool readOnly = true);
        //Task<DTO> GetAsync<DTO>(Expression<Func<Entity, bool>> predicate = null, bool readOnly = true);
        Task<IList<DTO>> GetAllAsync<DTO>(Expression<Func<Entity, bool>> predicate = null);
        //Task<IList<DTOResult>> GetAllAsync<EntityResult, DTOResult>(Expression<Func<Entity, EntityResult>> selector,
            //Expression<Func<Entity, bool>> predicate = null,
            //Func<IQueryable<Entity>,
            //IIncludableQueryable<Entity, object>> include = null,
            //bool noTraking = true);
        Task<bool> CreateAsync<DTO>(DTO dto);
        Task<bool> UpdateAsync<DTO>(DTO dto);
        Task<bool> DeleteAsync(Guid Id);
    }
}

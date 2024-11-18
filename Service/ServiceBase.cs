using Abstraction.Domain;
using Abstraction.Service;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceBase<Entity> : IServiceBase<Entity> where Entity : BaseEntity
    {
        private readonly IBaseRepository<Entity> _baseRepository;
        public static Guid UserId;

        public ServiceBase()
        {

        }
        public ServiceBase(IBaseRepository<Entity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<bool> CreateAsync<DTO>(DTO dto)
        {

            var entity = MapToEntity(dto);
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;
            entity.CreatorID = UserId;
            entity.UpdatorID = UserId;
            
            return await _baseRepository.CreateAsync(entity);
        }
        public virtual Task<bool> UpdateAsync<DTO>(DTO dto)
        {
            var entity = MapToEntity(dto);
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;
            return _baseRepository.UpdateAsync(entity);
        }
        public virtual async Task<bool> DeleteAsync(Guid Id)
        {
            return await _baseRepository.DeleteAsync(Id);
        }

        public virtual async Task<IList<DTO>> GetAllAsync<DTO>(Expression<Func<Entity, bool>> predicate = null)
        {
            var entities = await _baseRepository.GetAll(predicate: predicate).ToListAsync();
            IList<DTO> results = new List<DTO>();
            foreach (var entity in entities)
            {
                results.Add(MapToDTO<DTO>(entity));
            }
            return results;

        }


        public virtual Entity MapToEntity<DTO>(DTO dto)
        {
            return dto.Adapt<Entity>();
        }

        public virtual DTO MapToDTO<DTO>(Entity entity)
        {

            return entity.Adapt<DTO>();
        }
        public virtual TResult MapToCustom<TSource, TResult>(TSource src)
        {
            return src.Adapt<TResult>();
        }


    }
}

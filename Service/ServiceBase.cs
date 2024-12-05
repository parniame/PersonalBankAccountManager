using Abstraction.Domain;
using Abstraction.Service;
using Abstraction.Service.Exceptions;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Service
{
    public class ServiceBase<Entity> : IServiceBase<Entity> where Entity : BaseEntity
    {
        private readonly IBaseRepository<Entity> _baseRepository;
        public ServiceBase(IBaseRepository<Entity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<bool> CreateAsync<DTO>(DTO dto)
        {

            var entity = MapToEntity(dto);
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;


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
            var entities =  _baseRepository.GetAll(predicate: predicate);
            IList<DTO> results = entities.ProjectToType<DTO>().ToList();
            
            return results;

        }
        protected virtual async Task<bool> IsUniqueAsync(Entity uniqueOBJ, string nameOfUniqueProperty)

        {
            //Validate If This Property Exist
            var propertyInfo = uniqueOBJ.GetType().GetProperty(nameOfUniqueProperty);
            var value = propertyInfo.GetValue(uniqueOBJ, null);
            if (value == null)
            {// Will bw catched at Entity Service where it was called with incorrect property name
                throw new ItemNotFoundException(nameOfUniqueProperty);
            }
            //Validate If This Property Was Used Before.
            var param = Expression.Parameter(typeof(Entity));
            var condition = Expression.Lambda<Func<Entity, bool>>
                (Expression.Equal(
            Expression.Property(param, nameOfUniqueProperty),
            Expression.Constant(value, typeof(string))
                ),
                param
                );
            var entity = await _baseRepository.GetFirstAsync(condition);
            return entity == null;


        }
        protected async Task<bool> CreateUniqueAsync<DTO>(DTO dto, string nameOfUniqueProperty,string nameOfOBJ)
        {
            var entity = MapToEntity(dto);
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;

            bool isUnique = await IsUniqueAsync(entity, nameOfUniqueProperty);
            if (isUnique)
            {
                return await _baseRepository.CreateAsync(entity);
            }
            throw new DuplicateUniquePropertyException( nameOfOBJ);

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

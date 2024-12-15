using Abstraction.Domain;
using Abstraction.Service;
using Abstraction.Service.Exceptions;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

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
            where DTO : class
        {

            var entity = MapToEntity(dto);
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;


            return await _baseRepository.CreateAsync(entity);
        }
        public virtual Task<bool> UpdateAsync<DTO>(DTO dto)
            where DTO : class
        {
            var entity = MapToEntity(dto);
            entity.DateUpdated = DateTime.Now;
            return _baseRepository.UpdateAsync(entity);
        }
        public virtual async Task<bool> DeleteAsync(Guid Id)
        {
            var check = await _baseRepository.GetByIdAsync(Id);
            if (check == null)
            {
                throw new ItemNotFoundException("آیدی");
            }
            return await _baseRepository.DeleteAsync(Id);
        }
        public virtual async Task<DTO?> GetByIdAsync<DTO>(Guid Id, bool readOnly = true)
            where DTO : class
        {
            var entity = await _baseRepository.GetByIdAsync(Id, false);
            return entity == null ? null : MapToDTO<DTO>(entity);

        }

        public async Task<List<DTO>> GetAllAsync<DTO>()
            where DTO : class
        {
            var entities = _baseRepository.GetAll();
            List<DTO> results = await entities.ProjectToType<DTO>().ToListAsync();

            return results;

        }

        //<summary>
        //    -1: error
        //    1:ok
        //    0:not unique

        //    </summary>
        protected virtual async Task<int> IsUniqueAsync(Entity uniqueOBJ, string nameOfUniqueProperty)

        {
            //Validate If This Property Exist
            var propertyInfo = uniqueOBJ.GetType().GetProperty(nameOfUniqueProperty);

            var value = propertyInfo.GetValue(uniqueOBJ, null);
            if (value == null)
            {// Will bw catched at Entity Service where it was called with incorrect property name
                return -1;
            }


            //Validate If This Property Was Used Before.
            var param = Expression.Parameter(typeof(Entity));

            var condition = Expression.Lambda<Func<Entity, bool>>
                (Expression.Equal(
            Expression.Property(param, nameOfUniqueProperty),
            Expression.Constant(value, propertyInfo.PropertyType)
                ),
                param
                );
            var entity = await _baseRepository.GetFirstAsync(condition);
            return entity == null ? 1 : 0;


        }
        protected async Task<bool> CreateUniqueAsync<DTO>(DTO dto, string nameOfUniqueProperty, string nameOfOBJ)
        where DTO : class
        {
            var entity = MapToEntity(dto);
            entity.DateCreated = DateTime.Now;
            entity.DateUpdated = DateTime.Now;

            var isUnique = await IsUniqueAsync(entity, nameOfUniqueProperty);
            if (isUnique == 1)
            {
                return await _baseRepository.CreateAsync(entity);
            }
            else if (isUnique == 0)
            {
                throw new DuplicateUniquePropertyException(nameOfOBJ);
            }
            return false;


        }



        public virtual Entity MapToEntity<DTO>(DTO dto) where DTO : class

        {
            return dto.Adapt<Entity>();
        }

        public virtual DTO MapToDTO<DTO>(Entity entity)
       where DTO : class
        {

            return entity.Adapt<DTO>();
        }

    }
}

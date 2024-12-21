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
        Entity MapToEntity<DtO>(DtO dto) where DtO : class;
        DtO MapToDTO<DtO>(Entity entity) where DtO : class;
        Task<DTO> GetByIdAsync<DTO>(Guid Id, bool readOnly = true) where DTO : class; 
        Task<List<DTO>> GetAllAsync<DTO>()
            where DTO : class;
        Task<bool> CreateAsync<DTO>(DTO dto) where DTO : class;
        Task<bool> UpdateAsync<DTO>(DTO dto) where DTO : class;
        //Task<bool> DeleteAsync(Guid Id);
        
    }
}

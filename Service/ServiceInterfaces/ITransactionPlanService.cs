using Abstraction.Service;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface ITransactionPlanService : IServiceBase<TransactionPlan>
    {
        Task<bool> DeleteAsync(Guid Id, Guid userId);
        Task<List<DTO>> GetAllAsync<DTO>(Guid userId) where DTO : class;
        Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true) where DTO : class;
    }
}

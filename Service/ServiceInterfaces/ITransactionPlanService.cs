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
        Task<List<DTO>> GetAllAsync<DTO>(Guid userId) where DTO : class;
    }
}

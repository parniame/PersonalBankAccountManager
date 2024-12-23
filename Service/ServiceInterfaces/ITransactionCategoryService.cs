using Abstraction.Service;
using DataTransferObject;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface ITransactionCategoryService : IServiceBase<TransactionCategory>
    {
        Task<bool> CreateAsync(TransactionCategoryCommand categoryCommand);
        Task<bool> DeleteAsync(Guid Id);
        List<string> GetAllNameWithFilter(bool isPositive);
        List<DTO> GetAllWithFilter<DTO>(bool isPositive);
        
    }
}

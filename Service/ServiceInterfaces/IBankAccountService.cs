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
    public interface IBankAccountService : IServiceBase<BankAccount>
    {
        
        Task<bool> ChangeAmmountAsync(decimal amount, Guid userId, bool isPositive, Guid bankAccountId);
        Task<bool> DeleteAsync(Guid Id, Guid userId);
        Task<List<DTO>> GetAllAsync<DTO>(Guid userId) where DTO : class;
        Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true) where DTO : class;
        Task<bool> UpdateAsync(BankAccountCommand dto);
    }
}

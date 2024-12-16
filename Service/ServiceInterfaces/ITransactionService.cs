using Abstraction.Service;
using DataTransferObject;
using Models.Entities;

namespace Service.ServiceInterfaces
{
    public interface ITransactionService : IServiceBase<Transaction>
    {
        Task<bool> DeleteAnyTransactionWithThisBankAccountAsync(Guid bankAccountId);
        Task<bool> DeleteAsync(Guid Id, Guid userId);
        
        Task<bool> DeletePlannerAsync(Guid plannerId);
        Task<List<DTO>> GetAllAsync<DTO>(Guid userId) where DTO : class;
        Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true) where DTO : class;
        
        Task<bool> UpdateAsync(TransactionCommand dto);
    }
}

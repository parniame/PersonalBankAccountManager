using Abstraction.Service;
using Models.Entities;

namespace Service.ServiceInterfaces
{
    public interface ITransactionService : IServiceBase<Transaction>
    {
        Task<bool> DeleteAnyTransactionWithThisBankAccountAsync(Guid bankAccountId);
        Task<bool> DeleteAsync(Guid Id, Guid userId);
        Task<List<DTO>> GetAllAsync<DTO>(Guid userId) where DTO : class;
        Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true) where DTO : class;
        Task<bool> UpdateAsync<DTO>(DTO dto) where DTO : class;
        
    }
}

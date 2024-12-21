using Abstraction.Service;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Models.Entities;
using Shared;

namespace Service.ServiceInterfaces
{
    public interface ITransactionService : IServiceBase<Transaction>
    {
        Task<TransactionLists> GetChartListAsync(Guid userId);
        Task<bool> CreateAsync(TransactionCommand transactionCommand, IFormFile? file);
        Task<bool> DeleteAnyTransactionWithThisBankAccountAsync(Guid bankAccountId);
        Task<bool> DeleteAsync(Guid Id, Guid userId);
        Task<bool> DeletePlannerAsync(Guid plannerId);       
        Task<List<DTO>> GetAllAsync<DTO>(Guid userId) where DTO : class;
        Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true) where DTO : class;
        Task<bool> UpdateAsync(TransactionCommand dto, IFormFile? file, bool keepFile);
        Task<TransactionCategoryLists> GetTransactionWithCategoriesChartAsync(Guid userId);
        Task<dynamic> GetComareAsync<DTO>(Guid userId, DateTime? from, DateTime? to, bool isWithList = true) where DTO : class;
        
    }
}

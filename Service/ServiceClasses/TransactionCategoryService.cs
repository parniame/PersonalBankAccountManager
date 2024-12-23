using Abstraction.Domain;
using Abstraction.Service;
using Abstraction.Service.Exceptions;
using DataTransferObject;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Persistence.Repositories;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class TransactionCategoryService : ServiceBase<TransactionCategory>, ITransactionCategoryService
    {
        private readonly IBaseRepository<TransactionCategory> _transactionCategoryRepository;
        private readonly IBaseRepository<Transaction> _transactionRepository;
        public TransactionCategoryService(IBaseRepository<TransactionCategory> transactionCategoryRepository, IBaseRepository<Transaction> transactionRepository) : base(transactionCategoryRepository)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
            _transactionRepository = transactionRepository;
        }
        public  List<DTO> GetAllWithFilter<DTO>(bool isPositive)
        {
           var categories =  _transactionCategoryRepository.GetAll(x => x.IsWithdrawl == isPositive,true);

            return categories.ProjectToType<DTO>().ToList();
        }
        public List<string> GetAllNameWithFilter(bool isPositive)
        {
            var categories = _transactionCategoryRepository.GetAll<string>(x => x.Name,x => x.IsWithdrawl == isPositive,null, true);
            return categories.ToList();
            
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _transactionCategoryRepository.GetByIdAsync(Id, true);
                if (check != null)
                {

                    //delete category from transactions
                    var transactions = _transactionRepository.GetAll(x => x.CategoryId == Id, false).ToList();
                    var result = true;
                    if (transactions.Any())
                    {
                        foreach (var transaction in transactions)
                        {
                            transaction.CategoryId = null;
                        }

                         result = await _transactionRepository.CommitAsync() > 0;
                    }
                    
                    if (result)
                    {
                       await _transactionCategoryRepository.DeleteAsync(Id);

                    }

                    return result;



                }
            }

            throw new ItemNotFoundException("دسته بندی");
        }
        public async Task<bool> CreateAsync(TransactionCategoryCommand categoryCommand)

        {

            return await CreateUniqueAsync(categoryCommand, "Name", "دسته بندی");
        }
    }
}

using Abstraction.Domain;
using Abstraction.Service;
using Mapster;
using Models.Entities;
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
        public TransactionCategoryService(IBaseRepository<TransactionCategory> baseRepository, IBaseRepository<TransactionCategory> transactionCategoryRepository) : base(baseRepository)
        {
            _transactionCategoryRepository = transactionCategoryRepository;
        }
        public  List<DTO> GetAllWithFilter<DTO>(bool isPositive)
        {
           var categories =  _transactionCategoryRepository.GetAll(x => x.IsWithdrawl == isPositive,true);

            return categories.ProjectToType<DTO>().ToList();
        }
    }
}

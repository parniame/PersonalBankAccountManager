using Abstraction.Domain;
using Abstraction.Service;
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
        public TransactionCategoryService(IBaseRepository<TransactionCategory> baseRepository) : base(baseRepository)
        {
        }
    }
}

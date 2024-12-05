using Abstraction.Domain;
using Models.Entities;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{

    public class TransactionService : ServiceBase<Transaction>, ITransactionService
    {
        
        public TransactionService( IBaseRepository<Transaction> baseRepository) : base(baseRepository)
        {
            
        }
    }
}

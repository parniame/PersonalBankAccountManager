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
    public class BankAccountService : ServiceBase<BankAccount>, IBankAccountService
    {
        public BankAccountService(IBaseRepository<BankAccount> baseRepository) : base(baseRepository)
        {
        }
    }
}

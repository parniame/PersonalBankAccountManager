using Abstraction.Service;
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
        Task<bool> ChangeAmmountAsync(decimal amount, bool isPositive, Guid bankAccountId);
       
    }
}

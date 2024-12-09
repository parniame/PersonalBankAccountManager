using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using Models.Entities;
using Service.Exceptions;
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
        private readonly IBaseRepository<BankAccount> _bankAccountRepository;
        public BankAccountService(IBaseRepository<BankAccount> baseRepository) : base(baseRepository)
        {
            _bankAccountRepository = baseRepository;
        }

        public async Task<bool> ChangeAmmountAsync(decimal amount, bool isPositive, Guid bankAccountId)
        {
            var bankAccountEntity = await _bankAccountRepository.GetByIdAsync(bankAccountId, false);
            if (bankAccountEntity == null)
            {
                throw new ItemNotFoundException("حساب بانکی");
            }
            if (isPositive)
            {
                bankAccountEntity.Amount += amount;
            }
            else
            {
                if (bankAccountEntity.Amount - amount >= 0)
                {
                    bankAccountEntity.Amount -= amount;
                }
                else
                {
                    throw new OverdraftException(bankAccountEntity.Amount);
                }
            }

            var rowsAffectedCount = await _bankAccountRepository.CommitAsync();
            if (rowsAffectedCount <= 0)
            {
                return false;
            }
            return true;
        }
    }
}

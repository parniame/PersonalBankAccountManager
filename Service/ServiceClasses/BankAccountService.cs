using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using DataTransferObject;
using DocumentFormat.OpenXml.Office2010.Excel;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Persistence.Repositories;
using Service.Exceptions;
using Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceClasses
{
    public class BankAccountService : ServiceBase<BankAccount>, IBankAccountService
    {
        private readonly IBaseRepository<BankAccount> _bankAccountRepository;
        private readonly ITransactionService _transactionService;
        private readonly IUserService _userService;
        public BankAccountService(IBaseRepository<BankAccount> baseRepository, ITransactionService transactionService, IUserService userService) : base(baseRepository)
        {
            _bankAccountRepository = baseRepository;
            _transactionService = transactionService;
            _userService = userService;
        }


        public async Task<bool> ChangeAmmountAsync(decimal amount, Guid userId, bool isPositive, Guid bankAccountId)
        {
            var bankAccountEntity = await _bankAccountRepository.GetByIdAsync(bankAccountId, false);
            if (bankAccountEntity != null)
            {
                if (bankAccountEntity.UserId == userId)
                {
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
                throw new CodeErrorException();


            }
            throw new ItemNotFoundException("حساب بانکی");



        }
        public async Task<bool> DeleteAsync(Guid Id, Guid userId)
        {
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _bankAccountRepository.GetByIdAsync(Id);
                if (check != null)
                {
                    if (check.UserId == userId)
                    {
                        var result = await _transactionService.DeleteAnyTransactionWithThisBankAccountAsync(Id);

                        return await _bankAccountRepository.DeleteAsync(Id);
                    }
                    throw new CodeErrorException();

                }
            }

            throw new ItemNotFoundException("حساب بانکی");
        }
        
        public async Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true)
            where DTO : class
        {
            //check user
            var user = await _userService.GetUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _bankAccountRepository.GetByIdAsync(Id);
                if (check != null)
                {
                    if (check.UserId == userId)
                    {
                        var entity = await _bankAccountRepository.GetByIdAsync(Id, x => x.Include(x => x.Bank).Include(x => x.Bank.Picture), readOnly);

                        var test = MapToDTO<DTO>(entity);
                        return entity == null ? null : MapToDTO<DTO>(entity);
                    }
                    throw new CodeErrorException();
                }
            }
            throw new ItemNotFoundException("حساب بانکی");
        }
        public async Task<List<DTO>> GetAllAsync<DTO>(Guid userId)
        where DTO : class
        {
            //check user
            var user = await _userService.GetUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }
            var entities = _bankAccountRepository.GetAll(x => x.UserId == userId, true);
            if (!entities.Any())
            {
                throw new NoBankAccountException();
            }

            var results = await entities.ProjectToType<DTO>().ToListAsync();
            return results;


        }
        public async Task<bool> UpdateAsync(BankAccountCommand dto)

        {
            var dtoCheck = await _bankAccountRepository.GetByIdAsync(dto.Id);
            if (dtoCheck != null)
            {
                if (dtoCheck.UserId == dto.UserId)
                {
                    var entity = MapToEntity(dto);
                    entity.DateUpdated = DateTime.Now;
                    var list = new List<string>
            {
                "UserId",
                "Amount"
            };
                    return await _bankAccountRepository.UpdateAsync(entity, list);
                }

            }

            throw new CodeErrorException();
        }
    }
}

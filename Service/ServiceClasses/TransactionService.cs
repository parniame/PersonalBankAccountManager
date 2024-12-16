using Abstraction.Domain;
using Abstraction.Service.Exceptions;
using DataTransferObject;
using Mapster;
using Microsoft.EntityFrameworkCore;
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

    public class TransactionService : ServiceBase<Transaction>, ITransactionService
    {
        private readonly IBaseRepository<Transaction> _transactionRepository;
        private readonly IUserService _userService;

        public TransactionService(IBaseRepository<Transaction> transactionRepository, IUserService userService) : base(transactionRepository)
        {
            _transactionRepository = transactionRepository;
            _userService = userService;
        }
        public override async Task<bool> CreateAsync<DTO>(DTO dto)
            where DTO : class
        {
            return await CreateUniqueAsync(dto, "TransactionPlanId", "پرداخت پلنر تراکنش");
        }
        public async Task<bool> DeleteAnyTransactionWithThisBankAccountAsync(Guid bankAccountId)
        {
            return await _transactionRepository.DeleteListAsync(x => x.BankAccountId == bankAccountId); ;
        }
        public async Task<bool> DeletePlannerAsync(Guid plannerId)
        {
            var transactions =  _transactionRepository.GetAll(x => x.TransactionPlanId == plannerId,false).ToList();
            
            foreach(var transaction in transactions)
            {
                transaction.TransactionPlanId = null;
            }
            await _transactionRepository.CommitAsync();
            return true;
        }
        public async Task<List<DTO>> GetAllAsync<DTO>(Guid userId)
        where DTO : class
        {
            //check user
            var user = await _userService.GetCurrentUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }
            var entities = _transactionRepository.GetAll(x => x.UserId == userId, true);
            if (!entities.Any())
            {
                throw new NoBankAccountException();
            }

            var results = await entities.ProjectToType<DTO>().ToListAsync();
            return results;


        }
        public async Task<bool> DeleteAsync(Guid Id, Guid userId)
        {
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _transactionRepository.GetByIdAsync(Id);
                if (check != null)
                {
                    if (check.UserId == userId)
                    {

                        
                        return await _transactionRepository.DeleteAsync(Id);
                    }
                    throw new CodeErrorException();

                }
            }

            throw new ItemNotFoundException("تراکنش");
        }
        public async Task<DTO?> GetByIdAsync<DTO>(Guid Id, Guid userId, bool readOnly = true)
        where DTO : class
        {
            //check user
            var user = await _userService.GetCurrentUserAsync(userId.ToString());
            if (user == null)
            {
                throw new ItemNotFoundException("نام کاربری");
            }
            //Check if Id valid
            if (new Guid() != Id)
            {
                var check = await _transactionRepository.GetByIdAsync(Id);
                if (check != null)
                {
                    if (check.UserId == userId)
                    {
                        var entity = await _transactionRepository.GetByIdAsync(Id, x => x.Include(x => x.BankAccount).Include(x => x.BankAccount.Bank).Include(x => x.Category).Include(x => x.TransactionPlan), readOnly);

                        var test = MapToDTO<DTO>(entity);
                        return entity == null ? null : MapToDTO<DTO>(entity);
                    }
                    throw new CodeErrorException();
                }
            }
            throw new ItemNotFoundException("تراکنش ");
        }
        public async Task<bool> UpdateAsync(TransactionCommand dto)

        {
            var dtoCheck = await GetByIdAsync<TransactionCommand>(dto.Id);
            if (dtoCheck.UserId == dto.UserId)
            {
                var entity = MapToEntity(dto);
                entity.DateUpdated = DateTime.Now;
                var list = new List<string>
            {
                "UserId",
                "Amount",

                "IsWithdrawl",
                "TransactionPlanId",
                "BankAccountId"


            };
                return await _transactionRepository.UpdateAsync(entity, list);
            }

            throw new CodeErrorException();
        }


    }

}


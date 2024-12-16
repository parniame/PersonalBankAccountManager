using DataTransferObject;
using Mapster;
using Models.Entities;
using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.Mapster;
using Service.ServiceClasses;
using Service.ServiceInterfaces;
using System.Dynamic;

namespace PersonalBankAccountManager.Resources.Utilities
{
    public class Translator
    {
        private readonly IBankService _bankService;
        private readonly IBankAccountService _bankAccountService;
        private readonly ITransactionService _transactionService;
        private readonly ITransactionPlanService _transactionPlanService;

        public Translator(ITransactionPlanService transactionPlanService)
        {
            _transactionPlanService = transactionPlanService;
        }

        public Translator(IBankAccountService bankAccountService, ITransactionService transactionService)
        {
            _bankAccountService = bankAccountService;
            _transactionService = transactionService;
        }

        public Translator(IBankService bankService, IBankAccountService bankAccountService)
        {
            _bankService = bankService;
            _bankAccountService = bankAccountService;
        }

        public static TResult MapToCustom<TSource, TResult>(TSource src)
        {
            return src.Adapt<TResult>();
        }
        public static List<TResult> ProjectToCustom<TSource, TResult>(List<TSource> src)
        {
            var test1 = src.AsQueryable();
            var test2 = test1.ProjectToType<TResult>();
            return src.AsQueryable().ProjectToType<TResult>().ToList();
        }
        public async Task<List<BankAccountViewModel>> GetBankAccountViewModelsAsync(Guid userId)
        {
            //bring bankAccounts- to be used in other viewModels(Transaction)
            var bankAccountCommands = await _bankAccountService.GetAllAsync<BankAccountArgs>(userId);
            List<BankAccountViewModel> bankAccounts = ProjectToCustom<BankAccountArgs, BankAccountViewModel>(bankAccountCommands);
            return bankAccounts;
        }

        public async Task<List<BankViewModel>> GetBankViewModelsAsync()
        {
            //bring banks
            var bankCommands = await _bankService.GetAllAsync<BankArgs>();
            List<BankViewModel> banks = ProjectToCustom<BankArgs, BankViewModel>(bankCommands);
            return banks;
        }
        public async Task<List<BankAccountWithoutDetailsViewModel>> GetBankAccountWithoutDetailsAsync(Guid userId)
        {
            //bring bankAccounts
            var bankAccountResults = await _bankAccountService.GetAllAsync<BankAccountResult>(userId);
            
            List<BankAccountWithoutDetailsViewModel> bankAccounts = ProjectToCustom<BankAccountResult, BankAccountWithoutDetailsViewModel>(bankAccountResults);
            
            return bankAccounts;
        }
        public async Task<List<TransactionPlanWithoutDetails>> TransactionPlanWithoutDetailsAsync(Guid userId)
        {
            //bring plans
            var transactionResults = await _transactionPlanService.GetAllAsync<TransactionPlanResult>(userId);

            List<TransactionPlanWithoutDetails> transactionPlanWithoutDetails = ProjectToCustom<TransactionPlanResult, TransactionPlanWithoutDetails>(transactionResults);

            return transactionPlanWithoutDetails;
        }
        public async Task<List<TransactionWithoutDetails>> GetTransactionAsync(Guid userId)
        {
            //bring transactions
            var transactionResults = await _transactionService.GetAllAsync<TransactionArgs>(userId);

            List<TransactionWithoutDetails> transactionWithoutDetails = ProjectToCustom<TransactionArgs, TransactionWithoutDetails>(transactionResults);

            return transactionWithoutDetails;
        }



    }
}

using DataTransferObject;
using Mapster;
using PersonalBankAccountManager.Models;
using Service.ServiceInterfaces;
using System.Dynamic;
using Shared;

namespace PersonalBankAccountManager.Resources.Utilities
{
    public class Translator
    {
        private readonly IBankService _bankService;
        private readonly IBankAccountService _bankAccountService;
        private readonly ITransactionService _transactionService;
        private readonly ITransactionPlanService _transactionPlanService;

        //transactionPlan constructor
        public Translator(ITransactionPlanService transactionPlanService)
        {
            _transactionPlanService = transactionPlanService;
        }
        //transaction constructor
        public Translator(IBankAccountService bankAccountService, ITransactionService transactionService, ITransactionPlanService transactionPlanService)
        {
            _bankAccountService = bankAccountService;
            _transactionService = transactionService;
            _transactionPlanService = transactionPlanService;
        }
        //BankAccount constructor
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
            var transactionArgs = await _transactionService.GetAllAsync<TransactionArgs>(userId);

            List<TransactionWithoutDetails> transactionWithoutDetails = ProjectToCustom<TransactionArgs, TransactionWithoutDetails>(transactionArgs);

            return transactionWithoutDetails;
        }
        public async Task<dynamic> GetCompareTransactionAsync(Guid userId, DateTime? from, DateTime? to)
        {

            dynamic obj = await _transactionService.GetComareAsync<TransactionArgs>(userId, from, to);

            //bring compare
            CompareTransaction compareViewModel = obj.Compare;
            //bring transactions
            List<TransactionWithoutDetails> transactionWithoutDetails = ProjectToCustom<TransactionArgs, TransactionWithoutDetails>(obj.List);
            dynamic newObj = new ExpandoObject();
            newObj.CompareViewModel = compareViewModel;
            newObj.List = transactionWithoutDetails;

            return newObj;
        }

        public async Task<AddTransactionViewModel> GetAddTransactionViewModelAsync(Guid currentUserId)
        {
            var addTransactionViewModel2 = new AddTransactionViewModel();
            //bring bankAccounts
            List<BankAccountViewModel> bankAccounts = await GetBankAccountViewModelsAsync(currentUserId);
            //bring transactionPlans
            var transactionPlanCommands = await _transactionPlanService.GetAllAsync<TransactionPlanArgs>(currentUserId);
            var transactionPlans = Translator.ProjectToCustom<TransactionPlanArgs, TransactionPlanViewModel>(transactionPlanCommands);

            addTransactionViewModel2.BankAccountViewModels = bankAccounts;
            addTransactionViewModel2.TransactionPlanViewModels = transactionPlans;
            return addTransactionViewModel2;
        }

        public async Task<UpdateTransactionPlanViewModel> GetUpdateTransactionPlanViewModelAsync(Guid currentUserID,Guid plannerId)
        {
            var transactionPlanResult = await _transactionPlanService.GetByIdAsync<TransactionPlanResult>(plannerId, currentUserID);
            return   MapToCustom<TransactionPlanResult, UpdateTransactionPlanViewModel>(transactionPlanResult);
        }

        public async Task<UpdateTransactionViewModel> GetUpdateTransactionViewModelAsync(Guid transactionId, Guid currentUserId)
        {
            var transactionResult = await _transactionService.GetByIdAsync<TransactionArgs>(transactionId, currentUserId);
           return MapToCustom<TransactionArgs, UpdateTransactionViewModel>(transactionResult);
        }

        public async Task<AddBankAccountViewModel> GetBankAccountViewModelAsync()
        {
            var addBankAccountViewModel = new AddBankAccountViewModel();
            //bring banks
            List<BankViewModel> banks = await GetBankViewModelsAsync();
            addBankAccountViewModel.BankViewModels = banks;
            return addBankAccountViewModel;
        }
        public async Task<UpdateBankAccountViewModel> GetUpdateBankAccountViewModelAsync(Guid currentUserID,Guid bankAccountId)
        {
            
            var bankAccountCommand = await _bankAccountService.GetByIdAsync<BankAccountResult>(bankAccountId, currentUserID);
            var result = Translator.MapToCustom<BankAccountResult, UpdateBankAccountViewModel>(bankAccountCommand);
            result.BankViewModels = await GetBankViewModelsAsync();
            return result;
        }
    }
}

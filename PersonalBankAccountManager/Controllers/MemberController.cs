using Abstraction.Service.Exceptions;
using DataTransferObject;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceInterfaces;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{

    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
        private readonly IBankService _bankService;
        private readonly IBankAccountService _bankAccountService;
        private readonly ITransactionService _transactionService;
        private readonly ITransactionPlanService _transactionPlanService;
        private readonly ITransactionCategoryService _categoryService;
        private readonly ILogger<AdminController> _logger;

        public MemberController(IBankService bankService, ILogger<AdminController> logger, IBankAccountService bankAccountService, ITransactionPlanService transactionPlanService, ITransactionService transactionService, ITransactionCategoryService categoryService)
        {
            _bankService = bankService;
            _logger = logger;
            _bankAccountService = bankAccountService;
            _transactionPlanService = transactionPlanService;
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddBankAccount(string? errorMessage)
        {
            if (errorMessage != null)
            {
                TempData["ErrorMessage"] = errorMessage;
            }
            var addBankAccountViewModel = new AddBankAccountViewModel();
            //bring banks
            var bankCommands = _bankService.GetAll<BankCommand>();
            List<BankViewModel> banks = Utilities.ProjectToCustom<BankCommand, BankViewModel>(bankCommands);
            addBankAccountViewModel.BankViewModels = banks;
            return View(addBankAccountViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBankAccountPostAsync(AddBankAccountViewModel addBankAccountView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bankAccountCommand = Utilities.MapToCustom<AddBankAccountViewModel, BankAccountCommand>(addBankAccountView);
                    
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        bankAccountCommand.UserId = new Guid(currentUserId);
                        var result = await _bankAccountService.CreateAsync(bankAccountCommand);
                        TempData["SuccessMessage"] = " حساب با موفقیت ساخته شد";
                        return LocalRedirect("/Member/index");
                    }
                    else
                    {
                        throw new CodeErrorException();
                    }

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت  حساب مشکلی به وجود آمد");
                    //If error is in english
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;

                }

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "ساخت حساب با مشکل مواجه شد";

            }

            return RedirectToAction("AddBankAccount", new { errorMessage = TempData["ErrorMessage"]?.ToString() });
        }
        [HttpGet]
        public IActionResult AddTransactionPlan()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTransactionPlanPostAsync(TransactionPlanViewModel transactionPlanViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var transactionPlanCommand = Utilities.MapToCustom<TransactionPlanViewModel, TransactionPlanCommand>(transactionPlanViewModel);
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        transactionPlanCommand.UserId = new Guid(currentUserId);
                        var result = await _transactionPlanService.CreateAsync(transactionPlanCommand);
                        TempData["SuccessMessage"] = "  پلنر تراکنش  با موفقیت ساخته شد";
                        //var selectedDate = DateTime.Now.AddSeconds(30);

                        //BackgroundJob.Schedule(() => _transactionPlanService.DeleteAsync(new Guid( )), selectedDate);


                        return LocalRedirect("/Member/index");
                    }
                    else
                    {
                        throw new CodeErrorException();
                    }

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت  پلنر تراکنش  مشکلی به وجود آمد");
                    //If error is in english
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;
                }

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "ساخت پلنر تراکنش با مشکل مواجه شد";
            }
            return View("AddTransactionPlan");
        }
        [HttpGet]
        public IActionResult AddTransaction(string? errorMessage)
        {
            if (errorMessage != null)
            {
                TempData["ErrorMessage"] = errorMessage;
            }

            var addTransactionViewModel = new AddTransactionViewModel();
            //bring bankAccounts
            var bankAccountCommands = _bankAccountService.GetAll<BankAccountCommand>();
            List<BankAccountViewModel> bankAccounts = Utilities.ProjectToCustom<BankAccountCommand,BankAccountViewModel>(bankAccountCommands);
            //bring transactionPlans
            var transactionPlanCommands = _transactionPlanService.GetAll<TransactionPlanCommand>();
            var transactionCategoryViewModels = Utilities.ProjectToCustom<TransactionPlanCommand, TransactionPlanViewModel>(transactionPlanCommands);

            addTransactionViewModel.BankAccountViewModels = bankAccounts;
            addTransactionViewModel.TransactionPlanViewModels = transactionCategoryViewModels;
            return View(addTransactionViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddTransactionPostAsync(AddTransactionViewModel addTransactionViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bankAccountId = addTransactionViewModel.BankAccountId;
                    var amount = addTransactionViewModel.Amount;
                    var isPositive = addTransactionViewModel.IsWithdrawl;
                    var amountChangeResult = await _bankAccountService.ChangeAmmountAsync(amount, isPositive, bankAccountId);
                    if (!amountChangeResult)
                    {
                        throw new CodeErrorException();
                    }

                    var transactionCommand = Utilities.MapToCustom<AddTransactionViewModel, TransactionCommand>(addTransactionViewModel);
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        transactionCommand.UserId = new Guid(currentUserId);
                        var result = await _transactionService.CreateAsync(transactionCommand);
                        TempData["SuccessMessage"] = "   تراکنش  با موفقیت ساخته شد";
                        return LocalRedirect("/Member/index");
                    }
                    else
                    {
                        throw new CodeErrorException();
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت   تراکنش  مشکلی به وجود آمد");
                    //If error is in english
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;
                }

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "ساخت  تراکنش با مشکل مواجه شد";
            }

            return RedirectToAction("AddTransaction", new { errorMessage = TempData["ErrorMessage"].ToString() });
        }
        public IActionResult GetBankAccounts()
        {
            //bring bankAccounts
            var bankAccountCommands = _bankAccountService.GetAll<BankAccountCommand>();
            List<BankAccountViewModel> bankAccounts = Utilities.ProjectToCustom<BankAccountCommand, BankAccountViewModel>(bankAccountCommands);
            return View(bankAccounts);
        }
        public IActionResult GetCategories(bool isPositive)
        {
            //bring categories.. 
            var transactionCategoryCommands = _categoryService.GetAllWithFilter<TransactionCategoryCommand>(isPositive);
            var transactionCategories = Utilities.ProjectToCustom<TransactionCategoryCommand, TransactionCategoryViewModel>(transactionCategoryCommands);
            return PartialView("_GetCategories", transactionCategories);
        }
       
    }
}

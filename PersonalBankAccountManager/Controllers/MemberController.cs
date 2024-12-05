using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBankAccountManager.Models;
using Service.ServiceInterfaces;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{

    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
        private readonly IBankService _bankService;
        private readonly IBankAccountService _bankAccountService;

        private readonly ITransactionPlanService _transactionPlanService;
        private readonly ILogger<AdminController> _logger;

        public MemberController(IBankService bankService, ILogger<AdminController> logger, IBankAccountService bankAccountService, ITransactionPlanService transactionPlanService)
        {
            _bankService = bankService;
            _logger = logger;
            _bankAccountService = bankAccountService;
            _transactionPlanService = transactionPlanService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddBankAccount()
        {
            var addBankAccountViewModel = new AddBankAccountViewModel();
            var bankCommands = await _bankService.GetAllAsync<BankCommand>();
            List<BankViewModel> banks = new List<BankViewModel>();
            for(int i = 0;i< bankCommands.Count(); i++)
            {
                var bank = bankCommands[i].MapToBankViewModel();
                banks.Add(bank);
            }
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
                    var bankAccountCommand = _bankAccountService.MapToCustom<AddBankAccountViewModel, BankAccountCommand>(addBankAccountView);
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        bankAccountCommand.UserId = new Guid(currentUserId);
                        var result = await _bankAccountService.CreateAsync(bankAccountCommand);
                        TempData["SuccessMessage"] = " حساب با موفقیت ساخته شد";
                        return LocalRedirect("/Member/index");
                    }

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت  حساب مشکلی به وجود آمد");
                    //If error is in enlish
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        ViewData["ErrorMessage"] = e.Message;

                }

            }
            if (ViewData["ErrorMessage"] == null)
            {
                ViewData["ErrorMessage"] = "ساخت حساب با مشکل مواجه شد";
            }

            return LocalRedirect("/Member/AddBankAccount");
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
                    var transactionPlanCommand = _transactionPlanService.MapToCustom<TransactionPlanViewModel, TransactionPlanCommand>(transactionPlanViewModel);
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        transactionPlanCommand.UserId = new Guid(currentUserId);
                        var result = await _transactionPlanService.CreateAsync(transactionPlanCommand);
                        TempData["SuccessMessage"] = " ساخت پلنر تراکنش  با موفقیت ساخته شد";
                        return LocalRedirect("/Member/index");
                    }

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت  پلنر تراکنش  مشکلی به وجود آمد");
                    //If error is in enlish
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        ViewData["ErrorMessage"] = e.Message;
                }

            }
            if (ViewData["ErrorMessage"] == null)
            {
                ViewData["ErrorMessage"] = "ساخت پلنر تراکنش با مشکل مواجه شد";
            }
            return View("AddTransactionPlan");
        }
        [HttpGet]
        public async Task<IActionResult> AddTransaction()
        {
            
            var  addTransactionViewModel = new AddTransactionViewModel();
            var bankAccountCommands = await _bankAccountService.GetAllAsync<BankAccountCommand>();
            List<BankAccountViewModel> bankAccounts = new List<BankAccountViewModel>();
            for(int i = 0; i < bankAccountCommands.Count(); i++)
            {
                var bankAccount = bankAccountCommands[i].MapToBankAccountViewModel();
                bankAccounts.Add(bankAccount);
            }
            addTransactionViewModel.BankAccountViewModels = bankAccounts;
            return View(addTransactionViewModel);
        }
        [HttpPost]
        public IActionResult AddTransactionPostAsync(AddTransactionViewModel addTransactionViewModel)
        {
            throw new NotImplementedException();
        }
    }
}

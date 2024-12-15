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
        private readonly Translator _Utilities;
        private readonly ILogger<AdminController> _logger;

        public MemberController(IBankService bankService, ILogger<AdminController> logger, IBankAccountService bankAccountService, ITransactionPlanService transactionPlanService, ITransactionService transactionService, ITransactionCategoryService categoryService)
        {
            _bankService = bankService;
            _logger = logger;
            _bankAccountService = bankAccountService;
            _transactionPlanService = transactionPlanService;
            _transactionService = transactionService;
            _categoryService = categoryService;
            _Utilities = new Translator(bankService, bankAccountService,transactionService);
        }

        public IActionResult Index(string? errorMessage)
        {
            if (errorMessage != null)
            {
                TempData["ErrorMessage"] = errorMessage;
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddTransactionPlan()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTransactionPlanPostAsync(AddTransactionPlanViewModel transactionPlanViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var transactionPlanCommand = Translator.MapToCustom<AddTransactionPlanViewModel, TransactionPlanCommand>(transactionPlanViewModel);
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

                    throw new CodeErrorException();


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

    }
}

using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBankAccountManager.Models;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace PersonalBankAccountManager.Controllers
{
    
    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
        private readonly IBankService _bankService;
        private readonly IBankAccountService _bankAccountService;
        private readonly ILogger<AdminController> _logger;

        public MemberController(IBankService bankService, ILogger<AdminController> logger, IBankAccountService bankAccountService)
        {
            _bankService = bankService;
            _logger = logger;
            _bankAccountService = bankAccountService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AddBankAccount()
        {
            var addBankAccountViewModel = new AddBankAccountViewModel();
            
            addBankAccountViewModel.BankViewModels = (await _bankService.GetAllAsync<BankViewModel>()).ToList();
            return View(addBankAccountViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> AddBankAccountPostAsync(AddBankAccountViewModel addBankAccountView)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bankAccountCommand = _bankAccountService.MapToCustom<BankAccountViewModel,BankAccountCommand>(addBankAccountView.BankAccountViewModel);
                    bankAccountCommand.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var result = await _bankAccountService.CreateAsync(bankAccountCommand);
                    TempData["SuccessMessage"] = " حساب با موفقیت ساخته شد";
                    return LocalRedirect("/Member/index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت  حساب مشکلی به وجود آمد");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "اطلاعات وارد شده صحیح نیست";
            }
            return LocalRedirect("/Member/AddBankAccount");
        }
    }
}

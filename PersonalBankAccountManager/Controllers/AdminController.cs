using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTransferObject;
using Service.ServiceInterfaces;
using PersonalBankAccountManager.Models;
using Models.Entities;
using System.Security.Claims;

namespace PersonalBankAccountManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IBankService _bankService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IBankService bankService, ILogger<AdminController> logger)
        {
            _bankService = bankService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddBank()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBankPost(BankViewModel bankViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var bankDTO = _bankService.MapToCustom<BankViewModel, BankCommand>(bankViewModel);
                    bankDTO.CreatorID =  new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var result = await _bankService.CreateAsync(bankDTO);
                    TempData["SuccessMessage"] = "نوع حساب با موفقیت ساخته شد";
                    return LocalRedirect("/Admin/index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت نوع حساب مشکلی به وجود آمد");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            return View("AddBank");
        }
        public IActionResult AddTransactionCategory()
        {
            return View();
        }
    }
}

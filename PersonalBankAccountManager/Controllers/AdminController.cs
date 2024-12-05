using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTransferObject;
using Service.ServiceInterfaces;
using PersonalBankAccountManager.Models;
using Models.Entities;
using System.Security.Claims;
using Service.ServiceClasses;
using Persistence.Migrations;


namespace PersonalBankAccountManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IBankService _bankService;
        private readonly ITransactionCategoryService _transactionCategoryService;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IBankService bankService, ILogger<AdminController> logger, ITransactionCategoryService transactionCategoryService)
        {
            _bankService = bankService;
            _logger = logger;
            _transactionCategoryService = transactionCategoryService;
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
        public async Task<IActionResult> AddBankPost(AddBankViewModel bankViewModel)
        {


            if (ModelState.IsValid)
            {

                try{
                    var bankDTO = _bankService.MapToCustom<AddBankViewModel, BankCommand>(bankViewModel);
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        bankDTO.CreatorID = new Guid(currentUserId);
                        bankDTO.UpdatorID = bankDTO.CreatorID;
                    }
                    if (bankViewModel.File != null)
                        await _bankService.CreateBankWithFileAsync(bankDTO,bankViewModel.File);
                    else
                        await _bankService.CreateAsync(bankDTO);


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
        [HttpGet]
        public IActionResult AddTransactionCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTransactionCategoryPostAsync(TransactionCategoryViewModel transactionCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var transactionCategoryCommand = _bankService.MapToCustom<TransactionCategoryViewModel, TransactionCategoryCommand>(transactionCategoryViewModel);
                    transactionCategoryCommand.CreatorID = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    transactionCategoryCommand.UpdatorID = transactionCategoryCommand.CreatorID;
                    var result = await _transactionCategoryService.CreateAsync(transactionCategoryCommand);
                    TempData["SuccessMessage"] = "  دسته بندی تراکنش با موفقیت ساخته شد";
                    return LocalRedirect("/Admin/index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت دسته بندی تراکنش مشکلی به وجود آمد");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            return View("AddTransactionCategory");
        }

    }
}


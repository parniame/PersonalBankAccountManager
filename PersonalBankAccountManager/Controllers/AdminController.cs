using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DataTransferObject;
using Service.ServiceInterfaces;
using PersonalBankAccountManager.Models;
using Models.Entities;
using System.Security.Claims;
using Service.ServiceClasses;
using Persistence.Migrations;
using PersonalBankAccountManager.Resources.Utilities;


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

                try
                {
                    var bankDTO = Translator.MapToCustom<AddBankViewModel, BankCommand>(bankViewModel);
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        bankDTO.CreatorID = new Guid(currentUserId);
                        bankDTO.UpdatorID = bankDTO.CreatorID;
                    }
                    var result = false;
                    if (bankViewModel.File != null)
                        result = await _bankService.CreateBankWithFileAsync(bankDTO, bankViewModel.File);
                    else
                    {
                        result = await _bankService.CreateAsync(bankDTO);
                    }


                    if (result)
                    {
                        TempData["SuccessMessage"] = "نوع حساب با موفقیت ساخته شد";
                        return LocalRedirect("/Admin/index");
                    }

                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت نوع حساب مشکلی به وجود آمد");
                    TempData["ErrorMessage"] = e.Message;
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
        public async Task<IActionResult> AddTransactionCategoryPostAsync(AddTransactionCategoryViewModel transactionCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var transactionCategoryCommand = Translator.MapToCustom<AddTransactionCategoryViewModel, TransactionCategoryCommand>(transactionCategoryViewModel);
                    transactionCategoryCommand.CreatorID = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    transactionCategoryCommand.UpdatorID = transactionCategoryCommand.CreatorID;
                    var result = await _transactionCategoryService.CreateAsync(transactionCategoryCommand);
                    TempData["SuccessMessage"] = "  دسته بندی تراکنش با موفقیت ساخته شد";
                    return LocalRedirect("/Admin/index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت دسته بندی تراکنش مشکلی به وجود آمد");
                    TempData["ErrorMessage"] = e.Message;
                }
            }
            return View("AddTransactionCategory");
        }

    }
}


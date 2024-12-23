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
using System.Text.RegularExpressions;


namespace PersonalBankAccountManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IBankService _bankService;
        private readonly ITransactionCategoryService _transactionCategoryService;
        private readonly ILogger<AdminController> _logger;
        private readonly IUserService _userService;


        public AdminController(IBankService bankService, ILogger<AdminController> logger, ITransactionCategoryService transactionCategoryService, IUserService userService)
        {
            _bankService = bankService;
            _logger = logger;
            _transactionCategoryService = transactionCategoryService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
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
                    var bankDTO = Resources.Utilities.Translator.MapToCustom<AddBankViewModel, BankCommand>(bankViewModel);
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        bankDTO.CreatorID = new Guid(currentUserId);
                        bankDTO.UpdatorID = bankDTO.CreatorID;
                    }
                    var result = await _bankService.CreateAsync(bankDTO, bankViewModel.File);
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
                    return RedirectToAction("GetTransactionCategories");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در ساخت دسته بندی تراکنش مشکلی به وجود آمد");
                    TempData["ErrorMessage"] = e.Message;
                }
            }
            return View("AddTransactionCategory");
        }
        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            try
            {

                var banks = await _bankService.GetAllAsync<BankResult>();
                var bankViewModel = Translator.ProjectToCustom<BankResult, BankWithDetailsViewModel>(banks);
                return View(bankViewModel);


            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن صفحه   بانک ها مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن صفحه   بانک ها با مشکل مواجه شد";

            }

            return RedirectToAction("Index", "Admin");

        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var users = await _userService.GetAllUserAsync(new Guid(currentUserId));

                    var userWithDetails = Translator.ProjectToCustom<UserResult, UserWithDetailsViewModel>(users);
                    return View(userWithDetails);

                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن صفحه   کاربر ها مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن صفحه   کاربر ها با مشکل مواجه شد";

            }

            return RedirectToAction("Index", "Admin");

        }
        public async Task<IActionResult> GetTransactionCategories()
        {
            try
            {

                var categories = await _transactionCategoryService.GetAllAsync<CategoryResult>();
                var categoryWithDetails = Translator.ProjectToCustom<CategoryResult, CategoryWithDetailsViewModel>(categories);
                return View(categoryWithDetails);


            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن صفحه   بانک ها مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن صفحه   بانک ها با مشکل مواجه شد";

            }

            return RedirectToAction("Index", "Admin");

        }
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            try
            {
                await _userService.DeleteUserAsync(userId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "در  حذف  کاربر  مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;
                else
                    TempData["ErrorMessage"] = "احذف  کاربر با مشکل مواجه شد";

            }



            return RedirectToAction("GetUsers", "Admin");
        }
        public async Task<IActionResult> DeleteBank(Guid bankId)
        {
            try
            {
                await _bankService.DeleteAsync(bankId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "در  حذف  بانک  مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;
                else
                    TempData["ErrorMessage"] = "احذف  بانک با مشکل مواجه شد";

            }



            return RedirectToAction("GetBanks", "Admin");
        }
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            try
            {
                await _transactionCategoryService.DeleteAsync(categoryId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "در  حذف  بانک  مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;
                else
                    TempData["ErrorMessage"] = "احذف  بانک با مشکل مواجه شد";

            }



            return RedirectToAction("GetTransactionCategories", "Admin");
        }

    }
    

}



using Abstraction.Service.Exceptions;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceInterfaces;
using System.Dynamic;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{
    [Authorize(Roles = "Member")]
    public class BankAccountController : Controller
    {
        private readonly IBankAccountService _bankAccountService;
        private readonly IBankService _bankService;
        private readonly ILogger<AdminController> _logger;
        private readonly Translator _translator;



        public BankAccountController(IBankAccountService bankAccountService, IBankService bankService, ILogger<AdminController> logger, ITransactionService transactionService)
        {
            _bankAccountService = bankAccountService;
            _bankService = bankService;
            _logger = logger;
            _translator = new Translator(bankService, bankAccountService, transactionService);

        }


        //create
        [HttpGet]
        public async Task<IActionResult> AddBankAccount(string? errorMessage)
        {
            if (errorMessage != null)
            {
                TempData["ErrorMessage"] = errorMessage;
            }
            var addBankAccountViewModel = new AddBankAccountViewModel();
            //bring banks
            List<BankViewModel> banks = await _translator.GetBankViewModelsAsync();
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
                    var bankAccountCommand = Translator.MapToCustom<AddBankAccountViewModel, BankAccountCommand>(addBankAccountView);

                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        bankAccountCommand.UserId = new Guid(currentUserId);
                        var result = await _bankAccountService.CreateAsync(bankAccountCommand);
                        TempData["SuccessMessage"] = " حساب با موفقیت ساخته شد";
                        return LocalRedirect("/Member/index");
                    }

                    throw new CodeErrorException();
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
        //Read
        [HttpGet]
        public async Task<IActionResult> GetBankAccounts(string? errorMessage)
        {
            if (errorMessage != null)
            {
                TempData["ErrorMessage"] = errorMessage;
            }
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(currentUserId))
            {
                var guid = new Guid(currentUserId);
                //bring bankAccounts
                var bankAccounts = await _translator.GetBankAccountWithoutDetailsAsync(guid);

                return View(bankAccounts);
            }
            throw new CodeErrorException();
        }
        //Details
        public async Task<IActionResult> GetBankAccountDetails(Guid bankAccountId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var bankAccountResult = await _bankAccountService.GetByIdAsync<BankAccountResult>(bankAccountId, new Guid(currentUserId));
                    var details = Translator.MapToCustom<BankAccountResult, BankAccountDetailsViewModel>(bankAccountResult);
                    return PartialView("_GetBankAccountDetails", details);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن صفحه جزئیات  حساب مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن صفحه جزئیات حساب با مشکل مواجه شد";

            }


            return RedirectToAction("GetBankAccounts", new { errorMessage = TempData["ErrorMessage"] });
        }
        //Delete
        public async Task<IActionResult> DeleteBankAccount(Guid bankAccountId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var result = await _bankAccountService.DeleteAsync(bankAccountId, new Guid(currentUserId));
                    if (result)
                    {
                        TempData["SuccessMessage"] = " حساب با موفقیت حذف شد";
                        return LocalRedirect("/Member/index");
                    }

                }


                throw new CodeErrorException();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "در حذف  حساب مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "حذف حساب با مشکل مواجه شد";

            }


            return RedirectToAction("GetBankAccounts");
        }
        //update

        public async Task<IActionResult> UpdateBankAccount(Guid bankAccountId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var guid = new Guid(currentUserId);
                    var bankAccountCommand = await _bankAccountService.GetByIdAsync<BankAccountResult>(bankAccountId, guid);
                    var result = Translator.MapToCustom<BankAccountResult, UpdateBankAccountViewModel>(bankAccountCommand);
                    result.BankViewModels = await _translator.GetBankViewModelsAsync();
                    return View(result);


                }

                throw new CodeErrorException();

            }
            catch (Exception e)
            {
                _logger.LogError(e, "در  اوردن صفحه تغییر حساب مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن صفحه تغییر با مشکل مواجه شد";

            }


            return RedirectToAction("GetBankAccounts");

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBankAccountPostAsync(UpdateBankAccountViewModel updateBankAccountViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bankAccountCommand = Translator.MapToCustom<UpdateBankAccountViewModel, BankAccountCommand>(updateBankAccountViewModel);


                    var result = await _bankAccountService.UpdateAsync(bankAccountCommand);
                    if (result)
                    {
                        TempData["SuccessMessage"] = " حساب با موفقیت تغییر داده شد";
                        return LocalRedirect("/Member/index");

                    }


                    throw new CodeErrorException();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در تغییر  حساب مشکلی به وجود آمد");
                    //If error is in english
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;

                }

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "تغییر حساب با مشکل مواجه شد";

            }

            return RedirectToAction("GetBankAccounts", new { errorMessage = TempData["ErrorMessage"]?.ToString() });

        }
    }
}

using Abstraction.Service.Exceptions;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.MyAttributes;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceClasses;
using Service.ServiceInterfaces;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{
    [Authorize(Roles = "Member")]
    public class TransactionController : Controller
    {

        private readonly IBankAccountService _bankAccountService;
        private readonly ITransactionService _transactionService;
        private readonly ITransactionPlanService _transactionPlanService;
        private readonly ITransactionCategoryService _categoryService;
        
        private readonly Translator _translator;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(IBankAccountService bankAccountService, ITransactionService transactionService, ITransactionPlanService transactionPlanService, ILogger<TransactionController> logger, ITransactionCategoryService categoryService)
        {
            _bankAccountService = bankAccountService;
            _transactionService = transactionService;
            _transactionPlanService = transactionPlanService;

            _translator = new Translator(bankAccountService, transactionService);
            _logger = logger;
            _categoryService = categoryService;
        }

        //create
        [HttpGet]

        public async Task<IActionResult> AddTransaction(string? errorMessage)
        {
            try
            {
                
                if (errorMessage != null)
                {
                    TempData["ErrorMessage"] = errorMessage;
                }

                var addTransactionViewModel = new AddTransactionViewModel();
                //bring bankAccounts
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    List<BankAccountViewModel> bankAccounts = await _translator.GetBankAccountViewModelsAsync(new Guid(currentUserId));

                    //bring transactionPlans


                    var transactionPlanCommands = await _transactionPlanService.GetAllAsync<TransactionPlanArgs>(new Guid(currentUserId));
                    var transactionCategoryViewModels = Translator.ProjectToCustom<TransactionPlanArgs, TransactionPlanViewModel>(transactionPlanCommands);

                    addTransactionViewModel.BankAccountViewModels = bankAccounts;
                    addTransactionViewModel.TransactionPlanViewModels = transactionCategoryViewModels;
                    
                    return View(addTransactionViewModel);

                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن صفحه درج   تراکنش  مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;
            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن صفحه درج تراکنش با مشکل مواجه شد";
            }

            return RedirectToAction("Index", "Member", new { errorMessage = TempData["ErrorMessage"] });
        }



        [HttpPost]
        public async Task<IActionResult> AddTransactionPostAsync(AddTransactionViewModel addTransactionViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        var bankAccountId = addTransactionViewModel.BankAccountId;
                        var amount = addTransactionViewModel.Amount;
                        var isPositive = addTransactionViewModel.IsWithdrawl;

                        var amountChangeResult = await _bankAccountService.ChangeAmmountAsync(amount, new Guid(currentUserId), isPositive, bankAccountId);
                        if (amountChangeResult)
                        {
                            var transactionCommand = Translator.MapToCustom<AddTransactionViewModel, TransactionCommand>(addTransactionViewModel);

                            transactionCommand.UserId = new Guid(currentUserId);
                            var result = await _transactionService.CreateAsync(transactionCommand);
                            TempData["SuccessMessage"] = "   تراکنش  با موفقیت ساخته شد";
                            return LocalRedirect("/Member/index");
                        }


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

        public IActionResult GetCategories(bool isPositive, Guid categoryId = new Guid())
        {
            List<CategoryViewModel> categories = new List<CategoryViewModel>();
            try
            {
                if (categoryId != Guid.Empty)
                {
                    ViewData["categoryId"] = categoryId;
                }

                
                //bring categories.. 
                var transactionCategoryCommands = _categoryService.GetAllWithFilter<CategoryArgs>(isPositive);
                var transactionCategories = Translator.ProjectToCustom<CategoryArgs, CategoryViewModel>(transactionCategoryCommands);
                return PartialView("_GetCategories", transactionCategories);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن کتگوری ها    مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن کتگوری   با مشکل مواجه شد";

            }

            return RedirectToAction("AddTransaction", new { errorMessage = TempData["ErrorMessage"].ToString() });



        }
        //Read
        [HttpGet]
        public async Task<IActionResult> GetTransactions(string? errorMessage, string? successMessage)
        {
            try
            {
                if (errorMessage != null)
                {
                    TempData["ErrorMessage"] = errorMessage;
                }
                if (successMessage != null)
                {
                    TempData["SuccessMessage"] = successMessage;
                }
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var guid = new Guid(currentUserId);
                    //bring transactions
                    var transactionWithoutDetails = await _translator.GetTransactionAsync(guid);
                    return View(transactionWithoutDetails);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن لیست   تراکنش  مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;
            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = " اوردن لیست  تراکنش با مشکل مواجه شد";
            }

            return RedirectToAction("Index", "Member", new { errorMessage = TempData["ErrorMessage"] });

        }
        //Delete
        public async Task<IActionResult> DeleteTransaction(Guid transactionId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var result = await _transactionService.DeleteAsync(transactionId, new Guid(currentUserId));
                    if (result)
                    {
                        TempData["SuccessMessage"] = " تراکنش با موفقیت حذف شد";
                        return RedirectToAction("GetTransactions", new { successMessage = TempData["SuccessMessage"]?.ToString() });
                    }

                }




            }
            catch (Exception e)
            {
                _logger.LogError(e, "در حذف  تراکنش مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "حذف تراکنش با مشکل مواجه شد";

            }


            return RedirectToAction("GetTransactions", new { errorMessage = TempData["ErrorMessage"] });
        }
        //Details
        public async Task<IActionResult> GetTransactionDetails(Guid transactiontId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var transactionResult = await _transactionService.GetByIdAsync<TransactionArgs>(transactiontId, new Guid(currentUserId));
                    var details = Translator.MapToCustom<TransactionArgs, TransactionDetailsViewModel>(transactionResult);
                    return PartialView("_GetTransactionDetails", details);


                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن صفحه تغییر  تراکنش مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن صفحه تغییر تراکنش با مشکل مواجه شد";

            }


            return RedirectToAction("GetTransactions", new { errorMessage = TempData["ErrorMessage"] });

        }
        //Update

        public async Task<IActionResult> UpdateTransaction(Guid transactionId, string? errorMessage)
        {
            if (errorMessage != null)
            {
                TempData["ErrorMessage"] = errorMessage;
            }
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var guid = new Guid(currentUserId);
                    var transactionResult = await _transactionService.GetByIdAsync<TransactionArgs>(transactionId, guid);
                    var result = Translator.MapToCustom<TransactionArgs, UpdateTransactionViewModel>(transactionResult);

                    return View(result);


                }



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


            return RedirectToAction("GetTransactions", new { errorMessage = TempData["ErrorMessage"] });

        }
        [HttpPost]
        public async Task<IActionResult> UpdateTransactionPostAsync(UpdateTransactionViewModel updateTransactionViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var transactionResult = Translator.MapToCustom<UpdateTransactionViewModel, TransactionCommand>(updateTransactionViewModel);


                    var result = await _transactionService.UpdateAsync(transactionResult);
                    if (result)
                    {
                        TempData["SuccessMessage"] = " تراکنش با موفقیت تغییرداده شد";
                        return RedirectToAction("GetTransactions");
                    }




                }
                catch (Exception e)
                {
                    _logger.LogError(e, "در تغییر  تراکنش مشکلی به وجود آمد");
                    //If error is in english
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;

                }

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "تغییر تراکنش با مشکل مواجه شد";

            }

            return RedirectToAction("GetTransactions", new { errorMessage = TempData["ErrorMessage"]?.ToString() });

        }




    }
}



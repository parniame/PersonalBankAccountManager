using Abstraction.Service.Exceptions;
using DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models.Entities;
using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.MyAttributes;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceClasses;
using Service.ServiceInterfaces;
using Shared;
using System.Dynamic;
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

            _translator = new Translator(bankAccountService, transactionService, transactionPlanService);
            _logger = logger;
            _categoryService = categoryService;
        }

        //create
        [HttpGet]

        public async Task<IActionResult> AddTransaction()
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {

                    var addTransactionViewModel2 = await _translator.GetAddTransactionViewModelAsync(new Guid(currentUserId));
                    return View(addTransactionViewModel2);

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

            return RedirectToAction("Index", "Member");
        }



        [HttpPost]
        public async Task<IActionResult> AddTransactionPostAsync(AddTransactionViewModel addTransactionViewModel)
        {
            try
            {
                if (ModelState.IsValid)
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
                            if (addTransactionViewModel.TransactionPlanId.HasValue)
                                await _transactionPlanService.SetIsPaidAsync(addTransactionViewModel.TransactionPlanId.Value, new Guid(currentUserId));
                            var transactionCommand = Translator.MapToCustom<AddTransactionViewModel, TransactionCommand>(addTransactionViewModel);

                            transactionCommand.UserId = new Guid(currentUserId);

                            var result = await _transactionService.CreateAsync(transactionCommand, addTransactionViewModel.File);
                            if (result)
                            {
                                TempData["SuccessMessage"] = "   تراکنش  با موفقیت ساخته شد";
                                return RedirectToAction("Index", "Member");
                            }
                        }
                    }
                }
                else
                {
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        var addTransactionViewModel2 = await _translator.GetAddTransactionViewModelAsync(new Guid(currentUserId));
                        return View("AddTransaction", addTransactionViewModel2);
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
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "ساخت  تراکنش با مشکل مواجه شد";
            }


            return RedirectToAction("AddTransaction");
        }

        public IActionResult GetCategories(bool isPositive = false, Guid categoryId = new Guid())
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
                _logger.LogError(e, "در اوردن دسته بندی تراکنش ها    مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن دسته بندی تراکنش   با مشکل مواجه شد";

            }

            return RedirectToAction("AddTransaction");



        }
        //Read
        [HttpGet]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                
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

            return RedirectToAction("Index", "Member");

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
                        return RedirectToAction("GetTransactions");
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


            return RedirectToAction("GetTransactions");
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


            return RedirectToAction("GetTransactions");

        }
        //Update

        public async Task<IActionResult> UpdateTransaction(Guid transactionId)
        {
            
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {

                    var result = await _translator.GetUpdateTransactionViewModelAsync(transactionId, new Guid(currentUserId));

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


            return RedirectToAction("GetTransactions");

        }
        [HttpPost]
        public async Task<IActionResult> UpdateTransactionPostAsync(UpdateTransactionViewModel updateTransactionViewModel)
        {
            try
            {
                if (updateTransactionViewModel != null)
                {
                    //remove TillThisDateFarsi
                    if (ModelState.ContainsKey("TransactionPlanViewModel.Id"))
                    {
                        ModelState["TransactionPlanViewModel.Id"].ValidationState = ModelValidationState.Valid;
                        ModelState["TransactionPlanViewModel.Id"].Errors.Clear();
                    }
                    if (ModelState.ContainsKey("TransactionPlanViewModel.Name"))
                    {
                        ModelState["TransactionPlanViewModel.Name"].ValidationState = ModelValidationState.Valid;
                        ModelState["TransactionPlanViewModel.Name"].Errors.Clear();
                    }
                }

                if (ModelState.IsValid)
                {

                    var transactionCommand = Translator.MapToCustom<UpdateTransactionViewModel, TransactionCommand>(updateTransactionViewModel);
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {
                        transactionCommand.UserId = new Guid(currentUserId);
                        var result = await _transactionService.UpdateAsync(transactionCommand, updateTransactionViewModel.File,updateTransactionViewModel.KeepFile); 
                        if (result)
                        {
                            TempData["SuccessMessage"] = " تراکنش با موفقیت تغییرداده شد";
                            return RedirectToAction("GetTransactions");
                        }
                    }
                }
                else
                {
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {

                        var result = await _translator.GetUpdateTransactionViewModelAsync(updateTransactionViewModel.Id, new Guid(currentUserId));

                        return View("UpdateTransaction", result);


                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "در تغییر  تراکنش مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "تغییر تراکنش با مشکل مواجه شد";

            }

            return RedirectToAction("GetTransactions");

        }


        public async Task<IActionResult> Compare(DateTime? from, DateTime? to)
        {
            try
            {

                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {

                    var guid = new Guid(currentUserId);

                    dynamic obj = await _translator.GetCompareTransactionAsync(guid, from, to);


                    return View("CompareTransaction", obj);
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

            return View("CompareTransaction", new List<TransactionWithoutDetails>());



        }
        [HttpGet]
        public async Task<IActionResult> GetTransactionLineChart()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TransactionLists lists;
            if (!string.IsNullOrEmpty(currentUserId))
            {
                lists = await _transactionService.GetChartListAsync(new Guid(currentUserId));
            }
            else
            {
                lists = new TransactionLists()
                {
                    Amounts = new List<decimal>(),
                    Times = new List<DateTime> { DateTime.Now },

                };
            }
            return Json(lists);
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactionPieChart()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            TransactionCategoryLists lists;
            if (!string.IsNullOrEmpty(currentUserId))
            {
                lists = await _transactionService.GetTransactionWithCategoriesChartAsync(new Guid(currentUserId));
            }
            else
            {
                lists = new TransactionCategoryLists()
                {
                    Counts = new List<List<int>>(),
                    Categories = new List<List<string>>(),

                };
            }
            return Json(lists);
        }
        [HttpGet]
        public async Task<IActionResult> GetTransactionBarChart()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            CompareTransaction comareArgs;
            if (!string.IsNullOrEmpty(currentUserId))
            {
                
                 dynamic obj    =await _transactionService.GetComareAsync<Transaction>(new Guid(currentUserId),null,null,false);
                 comareArgs = obj.Compare;
            }
            else
            {
                comareArgs = new CompareTransaction()
                {
                    CountAll = 0,
                    CountAmountIn = 0,
                    CountAmountOut = 0,
                    AmountIn = 0,
                    AmountOut = 0,
                    TotalAmount = 0,
                };
            }
            return Json(comareArgs);
        }






    }
}



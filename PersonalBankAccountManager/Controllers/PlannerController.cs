using Abstraction.Service.Exceptions;
using DataTransferObject;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.MyAttributes;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceClasses;
using Service.ServiceInterfaces;
using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{
    [Authorize(Roles = "Member")]
    public class PlannerController : Controller
    {

        private readonly ITransactionPlanService _transactionPlanService;
        private readonly Translator _translator;
        private readonly ILogger<PlannerController> _logger;
        private readonly ITempDataDictionary test;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITempDataDictionaryFactory _tempDataDictionaryFactory;

        public PlannerController(ITransactionPlanService transactionPlanService, ILogger<PlannerController> logger, IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _transactionPlanService = transactionPlanService;
            _translator = new Translator(transactionPlanService);
            _logger = logger;

            _httpContextAccessor = httpContextAccessor;
            _tempDataDictionaryFactory = tempDataDictionaryFactory;
            //var test2 = _httpContextAccessor.HttpContext.RequestServices.GetService<ITempDataDictionaryFactory>();
            test = _tempDataDictionaryFactory.GetTempData(_httpContextAccessor.HttpContext);
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
                        return RedirectToAction("GetTransactionPlans");
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
            else
            {
                return View("AddTransactionPlan");
            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "ساخت پلنر تراکنش با مشکل مواجه شد";
            }
            return RedirectToAction("Index", "Member");
            
        }
        //Read
        [HttpGet]
        public async Task<IActionResult> GetTransactionPlans()
        {
            
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var guid = new Guid(currentUserId);
                    //bring plans
                    var transactionPlans = await _translator.TransactionPlanWithoutDetailsAsync(guid);

                    return View(transactionPlans);
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "در اوردن صفحه   پلنرها مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "اوردن صفحه  حساب پلنر ها با مشکل مواجه شد";

            }

            return RedirectToAction("Index", "Member");

        }
        //Delete
        public async Task<IActionResult> DeletePlanner(Guid plannerId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var result = await _transactionPlanService.DeleteAsync(plannerId, new Guid(currentUserId));
                    if (result)
                    {
                        TempData["SuccessMessage"] = " پلنر تراکنش با موفقیت حذف شد";
                        return RedirectToAction("GetTransactionPlans");
                    }

                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "در حذف  پلنر مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }

            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "حذف پلنر با مشکل مواجه شد";

            }

            return RedirectToAction("GetTransactionPlans");
        }
        //Details
        public async Task<IActionResult> GetPlannerDetails(Guid plannerId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var transactionPlanResult = await _transactionPlanService.GetByIdAsync<TransactionPlanResult>(plannerId, new Guid(currentUserId));
                    var details = Translator.MapToCustom<TransactionPlanResult, TransactionPlanDtailsViewModel>(transactionPlanResult);
                    return PartialView("_GetPlannerDetails", details);
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


            return RedirectToAction("GetTransactionPlans");
        }
        //update
        [HttpGet]
        public async Task<IActionResult> UpdatePlanner(Guid plannerId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {


                    var result = await _translator.GetUpdateTransactionPlanViewModelAsync(new Guid(currentUserId), plannerId);

                    return View("UpdateTransactionPlan", result);


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


            return RedirectToAction("GetTransactionPlans");


        }
        

        [HttpPost]
        public async Task<IActionResult> UpdatePlannerPostAsync(UpdateTransactionPlanViewModel updateTransactionPlanViewModel)
        {
            try
            {
                if (updateTransactionPlanViewModel != null)
                {
                    //remove TillThisDateFarsi
                    if (ModelState.ContainsKey("TillThisDateFarsi"))
                    {
                        ModelState["TillThisDateFarsi"].ValidationState = ModelValidationState.Valid;
                        ModelState["TillThisDateFarsi"].Errors.Clear();
                    }
                    if (updateTransactionPlanViewModel.IsPaid)
                    {
                        if (ModelState.ContainsKey("TillThisDate"))
                        {
                            ModelState["TillThisDate"].Errors.Clear();
                            ModelState["TillThisDate"].ValidationState = ModelValidationState.Valid;

                        }
                            
                    }
                    else
                    {
                        if (updateTransactionPlanViewModel.OldDateTime <= DateTime.Now)
                        {
                            ModelState["TillThisDate"].Errors.Clear();
                            ModelState["TillThisDate"].ValidationState = ModelValidationState.Valid;
                            var selectedDateTime = updateTransactionPlanViewModel.TillThisDate;

                            var selectedOnlyDate = new DateTime(selectedDateTime.Value.Year, selectedDateTime.Value.Month, selectedDateTime.Value.Day, selectedDateTime.Value.Hour, selectedDateTime.Value.Minute, 0);
                            var oldDate = updateTransactionPlanViewModel.OldDateTime;
                            var oldDateOnlyDate = new DateTime(oldDate.Year, oldDate.Month, oldDate.Day, oldDate.Hour, oldDate.Minute, 0);
                            if (selectedOnlyDate < oldDateOnlyDate)
                            {
                                ModelState["TillThisDate"].Errors.Add("باید برابر یا بیشتر از تایم قبلی باشد");
                                ModelState["TillThisDate"].ValidationState = ModelValidationState.Invalid;
                            }
                                
                        }

                    }
                    
                }

                if (ModelState.IsValid)
                {

                    var transactionPlanCommand = Translator.MapToCustom<UpdateTransactionPlanViewModel, TransactionPlanCommand>(updateTransactionPlanViewModel);

                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {

                        transactionPlanCommand.UserId = new Guid(currentUserId);
                        var result = await _transactionPlanService.UpdateAsync(transactionPlanCommand, updateTransactionPlanViewModel.IsPaid);
                        if (result)
                        {
                            TempData["SuccessMessage"] = "  پلن با موفقیت تغییر داده شد";
                            return RedirectToAction("GetTransactionPlans");

                        }
                    }





                }
                else
                {
                    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    if (!string.IsNullOrEmpty(currentUserId))
                    {


                        var result = await _translator.GetUpdateTransactionPlanViewModelAsync(new Guid(currentUserId), updateTransactionPlanViewModel.Id);

                        return View("UpdateTransactionPlan", result);


                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "در تغییر  پلن مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "تغییر پلن با مشکل مواجه شد";

            }



            return RedirectToAction("GetTransactionPlans");
        }
    }
}


using Abstraction.Service.Exceptions;
using DataTransferObject;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceClasses;
using Service.ServiceInterfaces;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{
    public class PlannerController : Controller
    {

        private readonly ITransactionPlanService _transactionPlanService;
        private readonly Translator _translator;
        private readonly ILogger<PlannerController> _logger;

        public PlannerController(ITransactionPlanService transactionPlanService, ILogger<PlannerController> logger)
        {
            _transactionPlanService = transactionPlanService;
            _translator = new Translator(transactionPlanService);
            _logger = logger;

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
                        
                        //BackgroundJob.Schedule(() =>  scheduleControler.CreatePlannerTimer(transactionPlanCommand.UniqueName),selectedDate));


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
        //Read
        [HttpGet]
        public async Task<IActionResult> GetTransactionPlans(string? errorMessage)
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

            return RedirectToAction("Index", "Member", new { errorMessage = TempData["ErrorMessage"] });

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


            return RedirectToAction("GetTransactionPlans", new { errorMessage = TempData["ErrorMessage"] });
        }
        //Details
        public async Task<IActionResult> GetPlannerDetails(Guid plannerId)
        {
            try
            {
                var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    var bankAccountResult = await _transactionPlanService.GetByIdAsync<TransactionPlanResult>(plannerId, new Guid(currentUserId));
                    var details = Translator.MapToCustom<TransactionPlanResult, TransactionPlanWithoutDetails>(bankAccountResult);
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


            return RedirectToAction("GetTransactionPlans", new { errorMessage = TempData["ErrorMessage"] });
        }
    }
}




using DataTransferObject;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace PersonalBankAccountManager.Controllers
{
    public class ScheduleController : Controller
    {
        private  PartialViewResult view;
        [HttpGet]
        public void CreatePlannerNotif(string plannerName)
        {
            ViewData["PlannerNotif"] = $"پلنر به این نام {plannerName} از زمان گذشته است";
            //TempData["Check"] = "hi";
            Console.WriteLine("hi");
            view =  PartialView("~/Views/Shared/_PlannerNotif.cshtml", plannerName);
        }
        [HttpPost]
        public void CreatePlannerTimer(string plannerName, DateTime dateTime)
        {
            var dateTime2 = DateTime.Now;
            var selectedDate = DateTimeOffset.Parse(dateTime2.ToString());
            var scheduleControler = new ScheduleController();

            //return View("~/Views/Shared/_PlannerNotif.cshtml", plannerName);
            //return RedirectToAction("CreatePlannerNotif", new { plannerName = plannerName });
            BackgroundJob.Schedule(() =>  scheduleControler.CreatePlannerNotif(plannerName), selectedDate);

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Optional: Work only for GET request
            if (filterContext.HttpContext.Request.Method != "GET")
            {
                var viewData = filterContext.HttpContext.RequestServices.GetRequiredService<ViewDataDictionary>();
                ViewData["PlannerNotif"] = $"پلنر به این نام از زمان گذشته است";
                return;
            }






        }

    }
}

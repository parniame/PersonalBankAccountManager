

using DataTransferObject;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBankAccountManager.Controllers
{
    //public class ScheduleController : Controller
    //{
        
    //    public IActionResult CreatePlannerNotif(string plannerName)
    //    {
    //        ViewData["PlannerNotif"] = $"پلنر به این نام {plannerName} از زمان گذشته است";
    //        TempData["Check"] = "hi";
    //        Console.WriteLine("hi");
    //        return View("~/Views/Shared/_PlannerNotif.cshtml", plannerName);
    //    }
    //    public  void CreatePlannerTimer(string plannerName, DateTime dateTime)
    //    {
    //        var selectedDate = DateTimeOffset.Parse(dateTime.ToString());
    //        //var scheduleControler = new ScheduleController();
    //        //scheduleControler.CreatePlannerNotif(plannerName);
    //        return RedirectToAction("CreatePlannerNotif", new { plannerName = plannerName });
    //         //BackgroundJob.Schedule(() => RedirectToAction("CreatePlannerNotif", plannerName), selectedDate);
            
    //    }

    //}
}

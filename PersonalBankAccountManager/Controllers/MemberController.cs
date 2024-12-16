using Abstraction.Service.Exceptions;
using DataTransferObject;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceInterfaces;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{

    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {
       
        private readonly ILogger<MemberController> _logger;

        public MemberController( ILogger<MemberController> logger)
        {
           
            _logger = logger;
            
        }

        public IActionResult Index(string? errorMessage)
        {
            var selectedDate = DateTime.Now.AddSeconds(30);
            var scheduleControler = new ScheduleController();
            scheduleControler.CreatePlannerTimer("random", selectedDate);
            if (errorMessage != null)
            {
                TempData["ErrorMessage"] = errorMessage;
            }
            return View();
        }

    

    }
}

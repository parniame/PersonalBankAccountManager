using Microsoft.AspNetCore.Mvc;

namespace PersonalBankAccountManager.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            TempData["hi"] = "hi";
            return View();
        }
    }
}

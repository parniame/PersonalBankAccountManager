using DataTransferObject;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using PersonalBankAccountManager.Models;
using Service.ServiceInterfaces;
using System.Security.Claims;

namespace PersonalBankAccountManager.Controllers
{
    public class AccountingController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<AccountingController> _logger;

        public AccountingController(IUserService userService, ILogger<AccountingController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> LoginPostAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _userService.LoginAsync(model.Adapt<LoginCommand>());
                
                if (result)
                {
                    TempData["SuccessMessage"] = "با موفقیت وارد شدید";
                    if (User.IsInRole("Admin"))
                    {
                        return LocalRedirect("/Admin/Index");
                    }
                    if (User.IsInRole("Member"))
                    {
                        return LocalRedirect("/Member/Index");
                    }

                    return LocalRedirect("/Home/Index");
                }

                ViewData["ErrorMessage"] = "ورود به مشکل مواجه شد";
            }
            return View("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPostAsync(RegisterViewModel model)
        {
            if(model != null) { }
            if (ModelState.IsValid)
            {

                try{
                    //registered users through home panel are always considered "Member"
                    var result = await _userService.RegisterAsync(model.Adapt<RegisterCommand>(),"Member");
                    TempData["SuccessMessage"] = "اکانت با موفقیت ساخته  شد";
                    return LocalRedirect("/Member/index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Something went wrong in registering new user.");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            return View("Register");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var username = User.Identity?.Name;
            if (!string.IsNullOrWhiteSpace(username))
            {
                try
                {
                    await _userService.LogoutAsync(username);
                    TempData["SuccessMessage"] = "با موفقیت خارج شدید";
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"Something went wrong when trying to log out user [{username}].");
                    ViewData["ErrorMessage"] = e.Message;
                }
            }
            return LocalRedirect("/Home/Index");
        }
    }
}

using DataTransferObject;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using PersonalBankAccountManager.Models;
using Service.ServiceInterfaces;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserService userService, ILogger<AccountController> logger)
        {
            _userService = userService;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost()]
        public async Task<IActionResult> LoginPostAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                

                try
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

                }
                catch (Exception e)
                {
                    
                    _logger.LogError(e, $"در ورود اکانت یوزر{model.UserName}، مشکلی وجود  دارد");
                    //If error is in enlish
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;

                }

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "ساخت اکانت با مشکل مواجه شد";
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

            if (ModelState.IsValid)
            {

                try
                {
                    //registered users through home panel are always considered "Member"
                    var result = await _userService.RegisterAsync(model.Adapt<RegisterCommand>(), "Member");
                    TempData["SuccessMessage"] = "اکانت با موفقیت ساخته  شد";
                    return LocalRedirect("/Member/index");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"در ساخت اکانت یوزر{model.UserName}، مشکلی وجود  دارد");
                    //If error is in enlish
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;

                }

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "ساخت اکانت با مشکل مواجه شد";
            }
            return View("Register");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            var username = User.FindFirstValue(ClaimTypes.Name);
            if (!string.IsNullOrWhiteSpace(username))
            {
                try
                {
                    await _userService.LogoutAsync(username);
                    TempData["SuccessMessage"] = "با موفقیت خارج شدید";
                }
                catch (Exception e)
                {
                    _logger.LogError(e, $"در خروج به مشکل مواجه شد [{username}]یوزر با نام کاربری ");
                    //If error is in enlish
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;

                }

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "خروج از اکانت با مشکل مواجه شد";
            }

            return LocalRedirect("/Home/Index");
        }

    }
}

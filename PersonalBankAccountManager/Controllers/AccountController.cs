using DataTransferObject;
using Humanizer;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models.Entities;
using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceClasses;
using Service.ServiceInterfaces;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Translator = PersonalBankAccountManager.Resources.Utilities.Translator;

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
                TempData["ErrorMessage"] = "ورود اکانت با مشکل مواجه شد";
            }
            return View("Login");
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrWhiteSpace(currentUserId))
            {
                try
                {

                    var userResult = await _userService.GetCurrentUserAsync(new Guid(currentUserId));
                    var userViewModel = Translator.MapToCustom<UserResult, UserWithDetailsViewModel>(userResult);
                    return View("UserProfile", userViewModel);
                }
                catch (Exception e)
                {

                    _logger.LogError(e, $"در ورود پروفایل یوزر، مشکلی وجود  دارد");
                    //If error is in enlish
                    if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                        TempData["ErrorMessage"] = e.Message;

                }
                if (TempData["ErrorMessage"] == null)
                {
                    TempData["ErrorMessage"] = "ساخت اکانت با مشکل مواجه شد";
                }

            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Member");
            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserAsync(UserWithDetailsViewModel user)
        {
            try
            {
                if (user != null)
                {
                    if(user.RoleName == "Admin")
                    {
                        ModelState["OldUsername"].ValidationState = ModelValidationState.Valid;
                        ModelState["OldUsername"].Errors.Clear();
                    }
                    if (user.Password == null)
                    {
                        //remove Password and Repassword validation
                        if (ModelState.ContainsKey("Password"))
                        {
                            ModelState["Password"].ValidationState = ModelValidationState.Valid;
                            ModelState["Password"].Errors.Clear();
                        }
                        if (ModelState.ContainsKey("RePassword"))
                        {
                            ModelState["RePassword"].ValidationState = ModelValidationState.Valid;
                            ModelState["RePassword"].Errors.Clear();
                        }
                    }
                    else
                    {
                        //remove non password entries
                        if (ModelState.ContainsKey("FirstName"))
                        {
                            ModelState["FirstName"].ValidationState = ModelValidationState.Valid;
                            ModelState["FirstName"].Errors.Clear();
                        }
                        if (ModelState.ContainsKey("LastName"))
                        {
                            ModelState["LastName"].ValidationState = ModelValidationState.Valid;
                            ModelState["LastName"].Errors.Clear();
                        }
                        if (ModelState.ContainsKey("DateOfBirth"))
                        {
                            ModelState["DateOfBirth"].ValidationState = ModelValidationState.Valid;
                            ModelState["DateOfBirth"].Errors.Clear();
                        }
                        if (ModelState.ContainsKey("PhoneNumber"))
                        {
                            ModelState["PhoneNumber"].ValidationState = ModelValidationState.Valid;
                            ModelState["PhoneNumber"].Errors.Clear();
                        }
                        if (ModelState.ContainsKey("Email"))
                        {
                            ModelState["Email"].ValidationState = ModelValidationState.Valid;
                            ModelState["Email"].Errors.Clear();
                        }


                    }


                }

                if (ModelState.IsValid)
                {
                    bool result = false;
                    if (user.Password == null)
                    {
                        var registerCommand = Translator.MapToCustom<UserWithDetailsViewModel, RegisterCommand>(user);
                        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                        if (!string.IsNullOrWhiteSpace(currentUserId))
                        {

                            result = await _userService.UpdateUserAsync(registerCommand, new Guid(currentUserId),user.OldUsername);
                        }
                    }
                    else
                    {

                        result = await _userService.UpdatePasswordAsync(user.UserName, user.Password);
                    }
                    if (result)
                    {
                        TempData["SuccessMessage"] = "اکانت با موفقیت تغییر داده  شد";
                        //logout user after change
                        await _userService.LogoutAsync(user.UserName);
                        return View("Login");

                    }
                }

            }
            catch (Exception e)
            {
                _logger.LogError(e, "در تغییر  اکانت مشکلی به وجود آمد");
                //If error is in english
                if (!Regex.IsMatch(e.Message, "^[\u0000-\u007F]+$"))
                    TempData["ErrorMessage"] = e.Message;

            }
            if (TempData["ErrorMessage"] == null)
            {
                TempData["ErrorMessage"] = "تغییر اکانت با مشکل مواجه شد";

            }

            return View("UserProfile", user);

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
            //It's out because we need it in 'catch'
            var username = User.FindFirstValue(ClaimTypes.Name);
            if (!string.IsNullOrWhiteSpace(username))
            {
                try
                {
                    await _userService.LogoutAsync(username);
                    TempData["SuccessMessage"] = "با موفقیت خارج شدید";
                    return View("Login");
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
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Member");
            }


        }

    }
}

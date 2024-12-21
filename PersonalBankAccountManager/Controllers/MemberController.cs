using Abstraction.Service.Exceptions;
using DataTransferObject;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using PersonalBankAccountManager.Models;
using PersonalBankAccountManager.Resources.Utilities;
using Service.ServiceInterfaces;
using Shared;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace PersonalBankAccountManager.Controllers
{

    [Authorize(Roles = "Member")]
    public class MemberController : Controller
    {

        private readonly ILogger<MemberController> _logger;
        private readonly ITransactionService _transactionService;

        public MemberController(ILogger<MemberController> logger, ITransactionService transactionService)
        {

            _logger = logger;
            _transactionService = transactionService;
        }

        public async Task<IActionResult> Index(string? errorMessage)
        {

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(currentUserId))
            {
                var test = await _transactionService.GetTransactionWithCategoriesChartAsync(new Guid (currentUserId));
            }
            return View("Charts");
        }




    }
}

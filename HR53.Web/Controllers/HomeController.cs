using HR53.Web.Extensions;
using HR53.Repository.Entities;
using HR53.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using HR53.Core.Models;
using HR53.Service.Services.Abstraction;

namespace HR53.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMemberService _memberService;
        private string username => User.Identity!.Name!;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMemberService memberService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
        {
            if (!ModelState.IsValid)
                return View();

            var identityResult = await _userManager.CreateAsync(new()
            {
                UserName = request.Name,
                Email = request.Email,
                PhoneNumber = request.Phone,
            }, request.PasswordConfirm);

            if (!identityResult.Succeeded)
            {
                ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
                return View();
            }


            var exchangeExpireClaim = new Claim("ExchangeExpireDate", DateTime.Now.AddDays(10).ToString());

            var user = await _userManager.FindByNameAsync(request.Name);

            var claimResult = await _userManager.AddClaimAsync(user, exchangeExpireClaim);

            if (!claimResult.Succeeded)
            {
                ModelState.AddModelErrorList(claimResult.Errors.Select(x => x.Description).ToList());
                return View();
            }

            TempData["SuccessMessage"] = "Üyelik işlemi başarıyla gerçekleşmiştir.";
            return RedirectToAction(nameof(HomeController.SignUp));
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel request, string? returnUrl = null)
        {
            //CompanyManager/Password/Reset
            //CompanyManager/Home/Index

            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var hasUser = await _userManager.FindByEmailAsync(request.Email);


            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email or password wrong");
                return View();
            }

            var hasUserRole = await _userManager.GetRolesAsync(hasUser);

            var isSiteManager = await _userManager.IsInRoleAsync(hasUser, "SiteManager");
            var isCompanyManager = await _userManager.IsInRoleAsync(hasUser, "CompanyManager");
            var isEmployee = await _userManager.IsInRoleAsync(hasUser, "Employee");

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);

            if (signInResult.Succeeded && isSiteManager)
                return RedirectToAction("Index", "Home", new { area = "SiteManager" });

            if (signInResult.Succeeded && isCompanyManager && hasUser.LoginCount == 0)
            {
                hasUser.LoginCount++;
                await _userManager.UpdateAsync(hasUser);
                return RedirectToAction("Reset", "Password", new { area = "CompanyManager" });
            }

            if (signInResult.Succeeded && isEmployee && hasUser.LoginCount == 0)
            {
                hasUser.LoginCount++;
                await _userManager.UpdateAsync(hasUser);
                return RedirectToAction("Reset", "Password", new { area = "Employees" });
            }

            if (signInResult.Succeeded && isCompanyManager && hasUser.LoginCount != 0)
                return RedirectToAction("Index", "Home", new { area = "CompanyManager" });

            if (signInResult.Succeeded && isEmployee && hasUser.LoginCount != 0)
                return RedirectToAction("Index", "Home", new { area = "Employees" });


            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "You can not login for 2 munites" });
                return View();
            }

            ModelState.AddModelErrorList(new List<string>()
            {
                $"Email or password wrong",
                $"Failed login attempt = {await _userManager.GetAccessFailedCountAsync(hasUser)}" });


            return View();
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            var message = string.Empty;

            message = "Bu sayfayı görmeye yetkiniz yoktur. Yetki almak için yöneticiniz ile görüşünüz.";

            ViewBag.Message = message;

            return View();
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
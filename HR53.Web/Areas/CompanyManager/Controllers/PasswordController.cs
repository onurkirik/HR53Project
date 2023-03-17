using HR53.Core.ViewModels;
using HR53.Repository.Entities;
using HR53.Service.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Data;

namespace HR53.Web.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "CompanyManager")]
    public class PasswordController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPasswordService _passwordService;
        public PasswordController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IPasswordService passwordService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _passwordService = passwordService;
        }

        public IActionResult Reset()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Reset(ResetPasswordViewModel request)
        {
            if (!ModelState.IsValid)
                return View();

            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var checkOldPassword = await _userManager.CheckPasswordAsync(currentUser, request.OldPassword);

            var changePasswordResult = await _userManager.ChangePasswordAsync(currentUser, request.OldPassword, request.NewPassword);



            if (!checkOldPassword)
            {
                ModelState.AddModelError(string.Empty, "Your old password is not right");
                return View();
            }

            await _passwordService.ChangePasswordAsync(request, currentUser);

            TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirilmiştir.";

            return View();
        }
    }
}

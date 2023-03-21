using HR53.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;

namespace HR53.Web.Areas.Employee.Controllers
{
    [Area("Employee")]
    //[Authorize(Roles = "Employee")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        public HomeController(UserManager<AppUser> userManager, IFileProvider fileProvider)
        {
            _userManager = userManager;
            _fileProvider = fileProvider;
        }
        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);


            return View(currentUser);
        }

    }
}

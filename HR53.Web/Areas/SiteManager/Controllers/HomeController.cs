using HR53.Web.Areas.SiteManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HR53.Web.Areas.SiteManager.Controllers
{
    [Authorize(Roles = "SiteManager")]
    [Area("SiteManager")]
    public class HomeController : Controller
    {
        public IActionResult Index(EmployeeVM vm)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //vm. = claim.Value;

            return View();
        }
    }
}
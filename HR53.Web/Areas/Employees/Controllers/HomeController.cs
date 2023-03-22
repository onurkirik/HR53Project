using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR53.Web.Areas.Employees.Controllers
{
    [Area("Employees")]
    [Authorize(Roles = "Employee")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

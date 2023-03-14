using Microsoft.AspNetCore.Mvc;

namespace HR53.Web.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace HR53.Web.Areas.CompanyManager.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

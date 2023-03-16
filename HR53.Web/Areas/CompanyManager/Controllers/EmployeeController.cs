using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR53.Web.Areas.CompanyManager.Controllers
{
    
    [Area("CompanyManager")]
    [Authorize(Roles ="CompanyManager")]
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

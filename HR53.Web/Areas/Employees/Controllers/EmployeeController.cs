using HR53.Repository.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Drawing;

namespace HR53.Web.Areas.Employees.Controllers
{
    [Area("Employees")]
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Advance()
        {

            ViewBag.Types = new SelectList(Enum.GetValues(typeof(TypesForEmployeeAdvanceandExpenditure))
                .Cast<TypesForEmployeeAdvanceandExpenditure>()
                .Select(e => new
                {
                    Key = (int)e,
                    Value = e.ToString()
                }), "Key", "Value");

            return View();
        }

        public async Task<IActionResult> Expense()
        {
            return View();
        }
    }
}

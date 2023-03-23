using HR53.Repository.Data;
using HR53.Repository.Entities;
using HR53.Repository.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _db;

        public EmployeeController(UserManager<AppUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

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

        [HttpPost]
        public async Task<IActionResult> Advance(EmployeeAdvance req)
        {
            int totalAmount = 0;
            string advanceCurrency = "";

            var currentUser = await _userManager.GetUserAsync(User);

            if(currentUser.TotalAmount >= currentUser.Salary * 3)
            {
                TempData["Warning1"] = "You have exceeded the advance limit";
                return RedirectToAction("Advance", "Employee");
            }

            var companyId = currentUser.CompanyIdString;

            var managers = await _userManager.GetUsersInRoleAsync("CompanyManager");
            var managerUser = managers.FirstOrDefault(m => m.CompanyIdString == companyId);
            var managerId = managerUser!.Id;

            req.CompanyId = companyId;
            req.ManagerId = managerId;

            if (req.Currency == 0.ToString())
                advanceCurrency = "₺";
            if (req.Currency == 1.ToString())
                advanceCurrency = "$";


            var newAdvance = new EmployeeAdvance()
            {
                Type = req.Type,
                Currency = advanceCurrency,
                ManagerId = managerId,
                CompanyId = companyId,
                Description = req.Description,
                Amount = req.Amount,
                ConfirmStatus = req.ConfirmStatus,
                RequestDate = req.RequestDate,
                UserId = currentUser.Id,
            };


            totalAmount += req.Amount;


            if (currentUser.Salary * 3 <= totalAmount)
            {
                TempData["Warning"] = "You have exceeded the amount of advance you can receive";
                return RedirectToAction("Advance", "Employee");
            }

            await _db.EmployeeAdvances.AddAsync(newAdvance);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AdvanceList()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var advances = _db.EmployeeAdvances.Where(a => a.UserId == currentUser.Id && a.CompanyId == currentUser.CompanyIdString).ToList();


            return View(advances);
        }

        public async Task<IActionResult> CancelAdvance(int advanceId)
        {
            var deleteToAdvance = await _db.EmployeeAdvances.FindAsync(advanceId);
            _db.EmployeeAdvances.Remove(deleteToAdvance!);
            await _db.SaveChangesAsync();
            return RedirectToAction("AdvanceList", "Employee");
        }

        public async Task<IActionResult> Expense()
        {
            return View();
        }
    }
}

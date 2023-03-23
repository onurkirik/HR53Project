using HR53.Repository.Data;
using HR53.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HR53.Repository.Enum;
using System.Data;

namespace HR53.Web.Areas.CompanyManager.Controllers
{
    [Area("CompanyManager")]
    [Authorize(Roles = "CompanyManager")]
    public class AdvanceController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _db;

        public AdvanceController(UserManager<AppUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public async Task<IActionResult> AdvanceList()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var advances = await _db.EmployeeAdvances.Include(a => a.User).Where(a => a.ManagerId == currentUser.Id).ToListAsync();


            return View(advances);
        }

        public async Task<IActionResult> Cancel(int advanceId)
        {
            var cancelToAdvance = await _db.EmployeeAdvances.FindAsync(advanceId);

            cancelToAdvance!.ReplyDate = DateTime.Now;
            cancelToAdvance.ConfirmStatus = ConfirmStatusForEmployee.Denied;

            _db.EmployeeAdvances.Update(cancelToAdvance);
            await _db.SaveChangesAsync();


            return RedirectToAction("AdvanceList", "Advance");
        }

        public async Task<IActionResult> Approve(int advanceId)
        {
            var approveToAdvance = await _db.EmployeeAdvances.FindAsync(advanceId);

            var user = await _userManager.FindByIdAsync(approveToAdvance!.UserId);

            user.TotalAmount += approveToAdvance.Amount;
            await _userManager.UpdateAsync(user);

            approveToAdvance!.ReplyDate = DateTime.Now;
            approveToAdvance.ConfirmStatus = ConfirmStatusForEmployee.Approved;

            _db.EmployeeAdvances.Update(approveToAdvance);
            await _db.SaveChangesAsync();


            return RedirectToAction("AdvanceList", "Advance");
        }

    }
}

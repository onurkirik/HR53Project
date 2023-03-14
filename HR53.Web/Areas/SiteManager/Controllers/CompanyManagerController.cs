using HR53.Web.Areas.SiteManager.ViewModels;
using HR53.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Data;
using HR53.Repository.Data;

namespace HR53.Web.Areas.SiteManager.Controllers
{
    [Authorize(Roles = "SiteManager")]
    [Area("SiteManager")]
    public class CompanyManagerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileProvider _fileProvider;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public CompanyManagerController(ApplicationDbContext db, IFileProvider fileProvider, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _db = db;
            _fileProvider = fileProvider;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "CompanyManager");

            var managers = await _userManager.GetUsersInRoleAsync("CompanyManager");

            return View(managers);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CompanyManagerAddViewModel request)
        {

            var role = await _roleManager.FindByNameAsync("CompanyManager");
            var roleName = role.Name;

            var emloyee = await _userManager.CreateAsync(new()
            {
                Firstname = request.Firstname,
                MiddleName = request.Middlename,
                LastName = request.Surname,
                SecondSurname = request.SecondSurname,
                Birthdate = request.Birthdate,
                Birthplace = request.Birthplace,
                IdentityCardNo = request.IdentityCardNo,
                EmploymentDate = request.EmploymentDate,
                Profession = request.Profession,
                Department = request.Department,
                Email = request.Email,
                Adress = request.Adress,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Firstname
            });

            var createdEmployee = await _userManager.FindByEmailAsync(request.Email);

            if (request.PhotoUrl != null && request.PhotoUrl.Length > 0)
            {
                var wwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.PhotoUrl.FileName)}";

                var newLogoPath = Path.Combine(wwrootFolder.First(x => x.Name == "images").PhysicalPath, randomFileName);

                using var stream = new FileStream(newLogoPath, FileMode.Create);

                await request.PhotoUrl.CopyToAsync(stream);
                createdEmployee.Picture = randomFileName;
                await _userManager.UpdateAsync(createdEmployee);
            }

            await _userManager.AddToRoleAsync(createdEmployee, roleName);

            return RedirectToAction("Index", "CompanyManager");
        }

        public async Task<IActionResult> Update(string managerId)
        {
            var manager = await _userManager.FindByIdAsync(managerId);

            var companies = await _db.Companies.Where(c => c.UserId == null).ToListAsync();

            var vm = new CompanyManagerUpdateViewModel()
            {
                User = manager,
                Companies = companies
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyManagerUpdateViewModel request)
        {
            var user = await _userManager.FindByIdAsync(request.User.Id);

            user.Firstname = request.User.Firstname;
            user.MiddleName = request.User.MiddleName;
            user.LastName = request.User.LastName;
            user.SecondSurname = request.User.SecondSurname;
            user.Birthdate = request.User.Birthdate;
            user.Birthplace = request.User.Birthplace;
            user.IdentityCardNo = request.User.IdentityCardNo;
            user.EmploymentDate = request.User.EmploymentDate;
            user.Profession = request.User.Profession;
            user.Department = request.User.Department;
            user.Email = request.User.Email;
            user.Adress = request.User.Adress;
            user.PhoneNumber = request.User.PhoneNumber;
            user.CompanyIdString = request.User.CompanyIdString;


            var result = await _userManager.UpdateAsync(user);


            return RedirectToAction("Index", "CompanyManager");
        }
    }
}

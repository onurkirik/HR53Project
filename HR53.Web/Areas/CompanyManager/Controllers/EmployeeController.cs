using HR53.Repository.Data;
using HR53.Repository.Entities;
using HR53.Service.Services.Abstraction;
using HR53.Web.Areas.SiteManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace HR53.Web.Areas.CompanyManager.Controllers
{

    [Area("CompanyManager")]
    [Authorize(Roles = "CompanyManager")]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMemberService _memberService;
        private readonly IPasswordService _passwordService;
        private readonly IEmailService _emailService;
        private readonly IFileProvider _fileProvider;

        public EmployeeController(ApplicationDbContext db, UserManager<AppUser> userManager, IFileProvider fileProvider, RoleManager<AppRole> roleManager, IPasswordService passwordService, IMemberService memberService, IEmailService emailService)
        {
            _db = db;
            _userManager = userManager;
            _fileProvider = fileProvider;
            _roleManager = roleManager;
            _passwordService = passwordService;
            _memberService = memberService;
            _emailService = emailService;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var employees = await _db.Users.Where(e => e.ManagerId == currentUser.Id).ToListAsync();

            return View(employees);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddViewModel request)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var companyId = currentUser.CompanyIdString;
            var role = await _roleManager.FindByNameAsync("Employee");
            var roleName = role.Name;
            var password = await _passwordService.GeneratePasswordAsync(2);
            request.Password = password + ".";
            var userName = _memberService.ConvertUsername(request.User.Firstname, request.User.MiddleName, request.User.LastName, request.User.SecondSurname);

            var signInLink = "https://hr53.azurewebsites.net/home/signin";

            var emloyee = await _userManager.CreateAsync(new()
            {
                Firstname = request.User.Firstname,
                MiddleName = request.User.MiddleName,
                LastName = request.User.LastName,
                SecondSurname = request.User.SecondSurname,
                Birthdate = request.User.Birthdate,
                Birthplace = request.User.Birthplace,
                IdentityCardNo = request.User.IdentityCardNo,
                EmploymentDate = request.User.EmploymentDate,
                Profession = request.User.Profession,
                Department = request.User.Department,
                Adress = request.User.Adress,
                PhoneNumber = request.User.PhoneNumber,
                CompanyIdString = companyId,
                UserName = userName,
                Email = _emailService.ConvertToEmail(request.User.Firstname, request.User.MiddleName, request.User.LastName, request.User.SecondSurname),
                Salary = request.User.Salary,
                ManagerId = currentUser.Id
            }, request.Password);





            var createdEmployee = await _userManager.FindByNameAsync(userName);

            if (request.PictureUrl != null && request.PictureUrl.Length > 0)
            {
                var wwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.PictureUrl.FileName)}";

                var newLogoPath = Path.Combine(wwrootFolder.First(x => x.Name == "images").PhysicalPath, randomFileName);

                using var stream = new FileStream(newLogoPath, FileMode.Create);

                await request.PictureUrl.CopyToAsync(stream);
                createdEmployee.Picture = randomFileName;
                await _userManager.UpdateAsync(createdEmployee);
            }

            await _userManager.AddToRoleAsync(createdEmployee, roleName);

            await _emailService.SendRegisterEmail(signInLink, createdEmployee.Email, password);

            return RedirectToAction("Index", "Home", new {area = "CompanyManager"});
        }

        
        public async Task<IActionResult> Delete(string employeeId)
        {
            var deleteToUser = await _userManager.FindByIdAsync(employeeId);

            await _userManager.DeleteAsync(deleteToUser);

            return RedirectToAction("Index", "Employee");
        }

    }

}


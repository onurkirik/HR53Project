using HR53.Web.Areas.SiteManager.ViewModels;
using HR53.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Data;
using HR53.Repository.Data;
using System.Collections.Generic;
using HR53.Service.Services.Abstraction;

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
        private readonly IEmailService _emailService;
        private readonly IMemberService _memberService;
        private readonly IPasswordService _passwordService;

        public CompanyManagerController(ApplicationDbContext db, IFileProvider fileProvider, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IEmailService emailService, IMemberService memberService, IPasswordService passwordService)
        {
            _db = db;
            _fileProvider = fileProvider;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _memberService = memberService;
            _passwordService = passwordService;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == "CompanyManager");

            var managers = await _userManager.GetUsersInRoleAsync("CompanyManager");

            return View(managers);
        }

        public async Task<IActionResult> Add()
        {

            var companies = await _db.Companies.ToListAsync();

            var vm = new CompanyManagerAddViewModel()
            {
                Companies = companies
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CompanyManagerAddViewModel request)
        {
            
            var role = await _roleManager.FindByNameAsync("CompanyManager");
            var roleName = role.Name;
            var password = await _passwordService.GeneratePasswordAsync(2);
            request.Password = password + ".";
            var userName = _memberService.ConvertUsername(request.User.Firstname, request.User.MiddleName, request.User.LastName, request.User.SecondSurname);

            var signInLink = "https://localhost:7084/home/signin";
                       
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
                CompanyIdString = request.User.CompanyIdString,
                UserName = userName,
                Email = _emailService.ConvertToEmail(request.User.Firstname, request.User.MiddleName, request.User.LastName, request.User.SecondSurname)
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

        public async Task<IActionResult> Delete(string managerId)
        {
            await _memberService.DeleteUserAsync(managerId);

            return RedirectToAction("Index", "CompanyManager");
        }
    }
}

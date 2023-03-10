using HR53.Web.Areas.SiteManager.ViewModels;
using HR53.Web.Data;
using HR53.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Data;

namespace HR53.Web.Areas.SiteManager.Controllers
{
    [Authorize(Roles = "SiteManager")]
    [Area("SiteManager")]
    public class CompanyManagerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileProvider _fileProvider;
        public CompanyManagerController(ApplicationDbContext db, IFileProvider fileProvider)
        {
            _db = db;
            _fileProvider = fileProvider;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _db.Employees.ToListAsync();


            return View(employees);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(CompanyManagerAddViewModel request)
        {
            
                var emloyee = new Employee()
                {
                    Firstname = request.Firstname,
                    Middlename = request.Middlename,
                    Surname = request.Surname,
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
                };

                if (request.PhotoUrl != null && request.PhotoUrl.Length > 0)
                {
                    var wwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                    var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.PhotoUrl.FileName)}";

                    var newLogoPath = Path.Combine(wwrootFolder.First(x => x.Name == "images").PhysicalPath, randomFileName);

                    using var stream = new FileStream(newLogoPath, FileMode.Create);

                    await request.PhotoUrl.CopyToAsync(stream);

                    emloyee.PhotoUrl = randomFileName;
                }

                await _db.Employees.AddAsync(emloyee);
                await _db.SaveChangesAsync();

                return RedirectToAction("Index", "CompanyManager");


        }
    }
}

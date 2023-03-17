using HR53.Core.ViewModels.CompanyManagerArea;
using HR53.Repository.Data;
using HR53.Repository.Entities;
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
        private readonly IFileProvider _fileProvider;

        public EmployeeController(ApplicationDbContext db, UserManager<AppUser> userManager, IFileProvider fileProvider)
        {
            _db = db;
            _userManager = userManager;
            _fileProvider = fileProvider;
        }
        public async Task<IActionResult> Index()
        {
            var companyManager = await _userManager.FindByNameAsync(User.Identity.Name);
            
            var employees = await _db.Employees.Where(e => e.CompanyId == companyManager.CompanyIdString).ToListAsync();

            return View(employees);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEmployeeViewModel request)
        {
            var companyManager = await _userManager.FindByNameAsync(User.Identity.Name);
            var companyId = companyManager.CompanyIdString;
            request.CompanyId = companyId;

            var employee = new Employee()
            {
                Id = Guid.NewGuid().ToString(),
                Firstname = request.Firstname,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                SecondSurname = request.SecondSurname,
                Adress = request.Adress,
                Birthdate = request.Birthdate,
                Birthplace = request.Birthplace,
                City = request.City,
                IdentityCardNo = request.IdentityCardNo,
                Department = request.Department,
                Profession = request.Profession,
                CompanyId = request.CompanyId,
            };


            if (request.Picture != null && request.Picture.Length > 0)
            {
                var wwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.Picture.FileName)}";

                var newPicturePath = Path.Combine(wwrootFolder.First(x => x.Name == "images").PhysicalPath, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);

                await request.Picture.CopyToAsync(stream);

                employee.Picture = randomFileName;
            }

            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();

            return View();
        }


    }

}


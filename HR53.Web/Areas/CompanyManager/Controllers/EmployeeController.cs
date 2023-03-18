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
        public async Task<IActionResult> Update(string employeeId)
        {
            var employee = await _db.Employees.FirstOrDefaultAsync(c => c.Id == employeeId);

            var vm = new UpdateEmployeeViewModel()
            {
                EmployeeId= employee.Id,
                Firstname = employee.Firstname,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                SecondSurname = employee.SecondSurname,
                Birthdate = employee.Birthdate,
                Birthplace = employee.Birthplace,
                IdentityCardNo = employee.IdentityCardNo,
                Adress = employee.Adress,
                Profession = employee.Profession,
                Department = employee.Department,
                City = employee.City,
                CompanyId = employee.CompanyId,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateEmployeeViewModel request)
        {
            var employeeToUpdate = await _db.Employees.FirstOrDefaultAsync(c => c.Id == request.EmployeeId);

            employeeToUpdate.Firstname = request.Firstname;
            employeeToUpdate.MiddleName = request.MiddleName;
            employeeToUpdate.LastName = request.LastName;
            employeeToUpdate.SecondSurname = request.SecondSurname;
            employeeToUpdate.Birthdate = request.Birthdate;
            employeeToUpdate.IdentityCardNo = request.IdentityCardNo;
            employeeToUpdate.Adress = request.Adress;
            employeeToUpdate.Profession = request.Profession;
            employeeToUpdate.Department = request.Department;
            employeeToUpdate.Adress = request.Adress;
            employeeToUpdate.City = request.City;
            employeeToUpdate.CompanyId = request.CompanyId;

            _db.Employees.Update(employeeToUpdate);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Employee");
        }

        public async Task<IActionResult> Delete(string employeeId)
        {
            var deleteEmployee = await _db.Employees.FindAsync(employeeId);
            _db.Employees.Remove(deleteEmployee);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Employee");
        }

    }

}


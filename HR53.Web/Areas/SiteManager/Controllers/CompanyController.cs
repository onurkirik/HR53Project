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
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IFileProvider _fileProvider;
        public CompanyController(ApplicationDbContext db, IFileProvider fileProvider)
        {
            _db = db;
            _fileProvider = fileProvider;
        }
        public async Task<IActionResult> Index()
        {
            var companies = await _db.Companies.ToListAsync();

            return View(companies);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyAddViewModel vm)
        {


            var newCompany = new Company()
            {
                CompanyName = vm.CompanyName,
                Title = vm.Title,
                MersisNumber = vm.MersisNumber,
                TaxOffice = vm.TaxOffice,
                TaxNumber = vm.TaxNumber,
                Phone = vm.Phone,
                Adress = vm.Adress,
                Email = vm.Email,
                TotalEmployeeNumber = vm.TotalEmployeeNumber,
                FoundationYear = vm.FoundationYear,
                ContractStartDate = vm.ContractStartDate,
                ContractFinishDate = vm.ContractFinishDate,
                IsActive = vm.IsActive
            };

            if(vm.Logo != null && vm.Logo.Length > 0)
            {
                var wwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(vm.Logo.FileName)}";

                var newLogoPath = Path.Combine(wwrootFolder.First(x => x.Name == "images").PhysicalPath, randomFileName);

                using var stream = new FileStream(newLogoPath, FileMode.Create);

                await vm.Logo.CopyToAsync(stream);

                newCompany.Logo = randomFileName;
            }

            await _db.Companies.AddAsync(newCompany);
            await _db.SaveChangesAsync();

            return View();
        }

    }
}
    
using HR53.Web.Areas.SiteManager.ViewModels;
using HR53.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Data;
using HR53.Repository.Data;

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

        public async Task<IActionResult> Update(string companyId)
        {
            var company = await _db.Companies.FirstOrDefaultAsync(c => c.Id == companyId);

            var vm = new CompanyUpdateViewModel()
            {
                CompanyId = company.Id,
                CompanyName = company.CompanyName,
                Title = company.Title,
                MersisNumber = company.MersisNumber,
                TaxOffice = company.TaxOffice,
                TaxNumber = company.TaxNumber,
                Phone = company.Phone,
                Adress = company.Adress,
                Email = company.Email,
                TotalEmployeeNumber = company.TotalEmployeeNumber,
                FoundationYear = company.FoundationYear,
                ContractStartDate = company.ContractStartDate,
                ContractFinishDate = company.ContractFinishDate,
                IsActive = company.IsActive
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CompanyUpdateViewModel request)
        {
            var companyToUpdate = await _db.Companies.FirstOrDefaultAsync(c => c.Id == request.CompanyId);

            companyToUpdate.CompanyName= request.CompanyName;
            companyToUpdate.Title= request.Title;
            companyToUpdate.MersisNumber= request.MersisNumber;
            companyToUpdate.TaxOffice= request.TaxOffice;
            companyToUpdate.TaxNumber= request.TaxNumber;
            companyToUpdate.Phone= request.Phone;
            companyToUpdate.Adress= request.Adress;
            companyToUpdate.Email= request.Email;
            companyToUpdate.TotalEmployeeNumber= request.TotalEmployeeNumber;
            companyToUpdate.FoundationYear= request.FoundationYear;
            companyToUpdate.ContractStartDate= request.ContractStartDate;
            companyToUpdate.ContractFinishDate= request.ContractFinishDate;
            companyToUpdate.IsActive= request.IsActive;

            _db.Companies.Update(companyToUpdate);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Company");
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
                Id = Guid.NewGuid().ToString(),
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

            return RedirectToAction("Index", "Company");
        }


    }
}
    
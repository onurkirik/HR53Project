using HR53.Web.Areas.SiteManager.ViewModels;
using HR53.Repository.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;

namespace HR53.Web.Areas.SiteManager.Controllers
{
    [Authorize(Roles = "SiteManager")]
    [Area("SiteManager")]
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        public HomeController(UserManager<AppUser> userManager, IFileProvider fileProvider)
        {
            _userManager = userManager;
            _fileProvider = fileProvider;
        }
        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);


            return View(currentUser);
        }

        public async Task<IActionResult> Details()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);

            ViewBag.Id = currentUserId;

            var userUpdateVm = new UserUpdateViewModel()
            {
                Id = currentUserId,
                FirstName = currentUser.Firstname,
                LastName = currentUser.LastName,
                Adress = currentUser.Adress,
                Department = currentUser.Department,
                City = currentUser.City,
                PhoneNumber = currentUser.PhoneNumber,
                Profession = currentUser.Profession
            };

            return View(userUpdateVm);
        }

        [Authorize(Roles ="SiteManager")]
        [HttpPost]
        public async Task<IActionResult> Details(UserUpdateViewModel vm)
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userToUpdate = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == currentUserId);


            userToUpdate.Firstname = vm.FirstName;
            userToUpdate.LastName = vm.LastName;
            userToUpdate.Adress = vm.Adress;
            userToUpdate.Profession = vm.Profession;
            userToUpdate.PhoneNumber = vm.PhoneNumber;
            userToUpdate.Department = vm.Department;
            userToUpdate.City = vm.City;
            
            
            if (vm.Picture != null && vm.Picture.Length > 0)
            {
                var wwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(vm.Picture.FileName)}";

                var newLogoPath = Path.Combine(wwrootFolder.First(x => x.Name == "images").PhysicalPath, randomFileName);

                using var stream = new FileStream(newLogoPath, FileMode.Create);

                await vm.Picture.CopyToAsync(stream);

                userToUpdate.Picture = randomFileName;
            }

            await _userManager.UpdateAsync(userToUpdate);

            return RedirectToAction("Index", "Home");
        }

        //private void DeletePicture(string photo)
        //{
        //    if (string.IsNullOrEmpty(photo))
        //        return;
        //    string filePath = Path.Combine(_env.WebRootPath, "img", photo);
        //    if (System.IO.File.Exists(filePath))
        //    {
        //        System.IO.File.Delete(filePath);
        //    }
        //}

    }
}
using HR53.Repository.Entities;
using HR53.Service.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Service.Services.Concrete
{
    public class MemberService : IMemberService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public MemberService(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task DeleteUserAsync(string id)
        {
            var deleteToUser = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(deleteToUser);
        }

        public async Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public string ConvertUsername(string firstname, string? middleName, string lastname, string? secondSurname)
        {
            var userName = $"{firstname}{middleName}{lastname}{secondSurname}";
            userName = userName.ToLower();
            userName = userName.Replace("ü", "u");
            userName = userName.Replace("ı", "i");
            userName = userName.Replace("ş", "s");
            userName = userName.Replace("ç", "c");
            userName = userName.Replace("ö", "o");

            if (userName.Contains(" "))
            {
                userName = userName.Replace(" ", "");
            }

            return userName;
        }
    }
}

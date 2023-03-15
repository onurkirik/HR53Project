using HR53.Repository.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Service.Services
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

        async public Task LogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}

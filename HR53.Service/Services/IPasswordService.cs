using HR53.Core.ViewModels;
using HR53.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR53.Service.Services
{
    public interface IPasswordService
    {
        Task<string>  GeneratePasswordAsync(int length);
        Task ChangePasswordAsync(ResetPasswordViewModel request, AppUser currentUser);


    }
}

﻿using HR53.Repository.Entities;
using Microsoft.AspNetCore.Identity;

namespace HR53.Web.CustomValidations
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new()
                {
                    Code = "PasswordContainUserName",
                    Description = "Password does not contain username"
                });
            }

            if (password.ToLower().Contains("1234"))
            {
                errors.Add(new()
                {
                    Code = "PasswordContainsBasicNumbers",
                    Description = "Password does not contain like 123 numbers."
                });
            }

            if (errors.Any())
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));

            return Task.FromResult(IdentityResult.Success);
        }
    }
}

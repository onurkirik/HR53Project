﻿using Microsoft.AspNetCore.Identity;

namespace HR53.Web.Localizations
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            //return base.DuplicateUserName(userName);
            return new() { Code = "DublicateUserName", Description = $"{userName} username used before by another user." };

        }

        public override IdentityError DuplicateEmail(string email)
        {
            //return base.DuplicateEmail(email);
            return new() { Code = "DuplicateEmail", Description = "This mail adress used before." };
        }
    }
}

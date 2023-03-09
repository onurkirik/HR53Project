﻿using HR53.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Drawing.Text;
using System.Security.Claims;
using HR53.Web.Models;

namespace HR53.Web.ClaimProviders
{
    public class UserClaimProvider : IClaimsTransformation
    {
        private readonly UserManager<AppUser> _userManager;

        public UserClaimProvider(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identityUser = principal.Identity as ClaimsIdentity;

            var currentUser = await _userManager.FindByNameAsync(identityUser.Name);

            if(currentUser == null)
            {
                return principal;
            }

            if(string.IsNullOrEmpty(currentUser.City))
            {
                return principal;
            }

            if (currentUser.City != null)
            {
                if (principal.HasClaim(x => x.Type != "city"))
                {
                    Claim cityClaim = new Claim("city", currentUser.City);
                    identityUser.AddClaim(cityClaim);
                }
            }

            return principal;

        }
    }
}

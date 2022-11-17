using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Authentication.Enums;

namespace TechNews.Authentication.Constants
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Admin)));
            await roleManager.CreateAsync(new IdentityRole(nameof(Roles.Member)));
        }
    }
}

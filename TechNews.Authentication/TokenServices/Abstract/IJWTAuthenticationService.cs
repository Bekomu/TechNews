using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.Authentication.TokenServices.Abstract
{
    public interface IJWTAuthenticationService
    {
        string GenerateToken(IdentityUser user);
    }
}

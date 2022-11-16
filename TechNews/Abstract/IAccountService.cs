using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.Result;
using TechNews.Dtos.Admins;

namespace TechNews.Business.Abstract
{
    public interface IAccountService
    {
        // TODO : authenticate yapılacak

        Task<IResult> CheckPasswordAsync(IdentityUser identityUser, string password);
        Task<IdentityResult> DeleteAsync(string identityId);
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Business.Abstract;
using TechNews.Core.Enums;
using TechNews.Core.Result;
using TechNews.Dtos.Admins;

namespace TechNews.Business.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AccountService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IResult> CheckPasswordAsync(IdentityUser identityUser, string password)
        {
            var passwordResult = await _userManager.CheckPasswordAsync(identityUser, password);
            if (!passwordResult)
            {
                return new Result(ResultStatus.Error);
            }

            return new Result(ResultStatus.Success);
        }

        public async Task<IdentityResult> DeleteAsync(string identityId)
        {
            var user = await _userManager.FindByIdAsync(identityId);
            if (user is null)
            {
                return IdentityResult.Failed(new IdentityError { Code = "UserNotFound", Description = "User not found!" });
            }

            return await _userManager.DeleteAsync(user);
        }
    }
}

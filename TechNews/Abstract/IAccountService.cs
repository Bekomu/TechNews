using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Authentication.DTOs;
using TechNews.Authentication.Results;
using TechNews.Core.Result;
using TechNews.Dtos.Admins;

namespace TechNews.Business.Abstract
{
    public interface IAccountService
    {
        Task<IDataResult<AdminDTO>> Register(RegisterDTO registerDTO);
        Task<AuthResult> Authenticate(string email);
        Task<IDataResult<IdentityUser>> FindByEmailAsync(string email);
        Task<IResult> CheckPasswordAsync(IdentityUser identityUser, string password);
        Task<IdentityResult> DeleteAsync(string identityId);
    }
}

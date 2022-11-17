using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Authentication.Results;
using TechNews.Authentication.TokenServices.Abstract;
using TechNews.Business.Abstract;
using TechNews.Core.Enums;
using TechNews.Core.Result;
using TechNews.DataAccess.Abstract;
using TechNews.DataAccess.Abstract.JWT;
using TechNews.Dtos.Admins;
using TechNews.Entity.Concrete;
using TechNews.Entity.Concrete.JWT;

namespace TechNews.Business.Concrete
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IJWTAuthenticationService _jWTAuthenticationService;
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AccountService(UserManager<IdentityUser> userManager, IJWTAuthenticationService jWTAuthenticationService, IRefreshTokenRepository refreshTokenRepository, IMapper mapper, IAdminRepository adminRepository)
        {
            _userManager = userManager;
            _jWTAuthenticationService = jWTAuthenticationService;
            _mapper = mapper;
            _adminRepository = adminRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        // TODO : önemli

        private async Task AddRefreshToken(string userId)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                Token = $"{RandomStringGenerator(25)}_{Guid.NewGuid()}",
                UserId = userId,
                ExpirationDate = DateTime.UtcNow.AddMonths(1),
            };
            await _refreshTokenRepository.Add(refreshToken);
        }


        //--------------
        public async Task<IDataResult<AdminDTO>> Register(AdminCreateDTO createAdminDto)
        {
            var createdAdmin = _mapper.Map<Admin>(createAdminDto);
            var newUser = new IdentityUser()
            {
                Email = createdAdmin.Email,
                NormalizedEmail = createdAdmin.Email.ToUpper(),
                UserName = createdAdmin.UserName,
                NormalizedUserName = createdAdmin.UserName.ToUpper(),
                EmailConfirmed = true
            };

            IdentityResult identityResult = await _userManager.CreateAsync(newUser, createAdminDto.Password);

            if (!identityResult.Succeeded)
            {
                return new DataResult<AdminDTO>(ResultStatus.Error, $"Admin couldn't be added - {identityResult}", null);
            }

            IdentityUser user = await _userManager.FindByEmailAsync(createdAdmin.Email);
            await _userManager.AddToRoleAsync(user, nameof(Roles.Admin));

            createdAdmin.IdentityId = user.Id;
            await _adminRepository.Add(createdAdmin);
            var result = _mapper.Map<AdminDTO>(createdAdmin);

            await AddRefreshToken(user.Id);

            return new DataResult<AdminDTO>(ResultStatus.Success, result);
        }
        //--------------


        public async Task<AuthResult> Authenticate(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var token = _jWTAuthenticationService.GenerateToken(user);
            return new AuthResult { IsSuccess = true, Token = token, };
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

        public async Task<IDataResult<IdentityUser>> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return new DataResult<IdentityUser>(ResultStatus.Error, "User not found.", null);
            }

            return new DataResult<IdentityUser>(ResultStatus.Success, user);
        }

        private string RandomStringGenerator(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
            .Select(a => a[random.Next(a.Length)]).ToArray());
        }
    }
}

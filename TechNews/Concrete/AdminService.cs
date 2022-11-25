using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Authentication.DTOs;
using TechNews.Business.Abstract;
using TechNews.Core.Enums;
using TechNews.Core.Result;
using TechNews.DataAccess.Abstract;
using TechNews.Dtos.Admins;
using TechNews.Entity.Concrete;

namespace TechNews.Business.Concrete
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAccountService _accountService;

        public AdminService(IAdminRepository adminRepository, IMapper mapper, UserManager<IdentityUser> userManager, IAccountService accountService)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _userManager = userManager;
            _accountService = accountService;
        }

        public async Task<IResult> Delete(Guid id)
        {
            var admin = await _adminRepository.GetById(id);
            if (admin == null)
            {
                return new Result(ResultStatus.Error, message: "Admin not found.");
            }

            var identityResult = await _accountService.DeleteAsync(admin.IdentityId);
            if (!identityResult.Succeeded)
            {
                return new Result(ResultStatus.Error, $"Error occured when deleting admin - {identityResult}");
            }

            await _adminRepository.Delete(admin);
            return new Result(ResultStatus.Success, message: $"{admin.Name} {admin.Surname} named admin deleted.");
        }

        public async Task<IDataResult<List<AdminDTO>>> GetAll()
        {
            var admins = await _adminRepository.GetAll();
            var datas = _mapper.Map<List<AdminDTO>>(admins);

            return new DataResult<List<AdminDTO>>(ResultStatus.Success, datas);
        }

        public async Task<IDataResult<AdminDTO>> GetByEmail(string email)
        {
            var admin = await _adminRepository.GetByEmail(email);

            var adminDto = _mapper.Map<AdminDTO>(admin);

            return new DataResult<AdminDTO>(ResultStatus.Success, adminDto);
        }

        public async Task<IDataResult<AdminDTO>> GetById(Guid id)
        {
            var admin = await _adminRepository.GetById(id);
            if (admin == null) return new DataResult<AdminDTO>(ResultStatus.Error, "Admin not found.", null);
            AdminDTO adminDto = _mapper.Map<AdminDTO>(admin);
            return new DataResult<AdminDTO>(ResultStatus.Success, adminDto);
        }

        public async Task<IDataResult<AdminDTO>> Update(AdminUpdateDTO updateAdminDto)
        {
            var admin = await _adminRepository.GetById(updateAdminDto.Id);
            var updateAdmin = _mapper.Map(updateAdminDto, admin);
            await _adminRepository.Update(updateAdmin);
            var adminDto = _mapper.Map<AdminDTO>(updateAdmin);
            return new DataResult<AdminDTO>(ResultStatus.Success, adminDto);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechNews.Authentication.DTOs;
using TechNews.Business.Abstract;
using TechNews.Core.Enums;

namespace TechNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAdminService _adminService;

        public AccountController(IAccountService accountService, IAdminService adminService)
        {
            _accountService = accountService;
            _adminService = adminService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Authenticate(LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailCheckResult = await _accountService.FindByEmailAsync(loginDto.Email);

            if (emailCheckResult.ResultStatus != ResultStatus.Success)
            {
                return BadRequest(emailCheckResult);
            }

            var passwordCheckResult = await _accountService.CheckPasswordAsync(emailCheckResult.Data, loginDto.Password);

            if (passwordCheckResult.ResultStatus != ResultStatus.Success)
            {
                return BadRequest(passwordCheckResult);
            }

            var result = await _accountService.Authenticate(loginDto.Email);

            return Ok(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _adminService.Add(registerDTO);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}

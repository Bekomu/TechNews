using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using TechNews.Business.Abstract;
using TechNews.Core.Enums;
using TechNews.Dtos.Admins;

namespace TechNews.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _adminService.GetAll();

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _adminService.GetById(id);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetByEmail")]
        public async Task<IActionResult> GetByEmail()
        {
            var headerString = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(headerString))
            {
                return Unauthorized();
            }

            var headerToken = "";
            if (AuthenticationHeaderValue.TryParse(headerString, out var headerValue))
            {
                headerToken = headerValue.Parameter;
            }
            var token = new JwtSecurityToken(jwtEncodedString: headerToken);
            var email = token.Claims.First(x => x.Type == "email").Value;

            var result = await _adminService.GetByEmail(email);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] AdminUpdateDTO adminUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _adminService.Update(adminUpdateDto);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _adminService.Delete(id);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}

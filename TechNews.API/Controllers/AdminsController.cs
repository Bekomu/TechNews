using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechNews.Business.Abstract;
using TechNews.Core.Enums;
using TechNews.Dtos.Admins;

namespace TechNews.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

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

        [HttpPost]
        public async Task<IActionResult> Add(AdminCreateDTO createAdminDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _adminService.Add(createAdminDto);

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

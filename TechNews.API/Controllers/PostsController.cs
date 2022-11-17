using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechNews.Business.Abstract;
using TechNews.Core.Enums;
using TechNews.DTOs.Posts;

namespace TechNews.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _postService.GetAll();

            if(result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _postService.GetById(id);

            if(result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetAuthorsPosts")]
        public async Task<IActionResult> GetAuthorPosts(Guid id)
        {
            var result = await _postService.GetAllByAuthorId(id);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(PostCreateDTO postCreateDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _postService.Add(postCreateDTO);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(PostUpdateDTO postUpdateDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _postService.Update(postUpdateDTO);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _postService.Delete(id);

            if (result.ResultStatus != ResultStatus.Success) return BadRequest(result);

            return Ok(result);
        }

    }
}

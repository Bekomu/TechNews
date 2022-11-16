using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Business.Abstract;
using TechNews.Core.Enums;
using TechNews.Core.Result;
using TechNews.DataAccess.Abstract;
using TechNews.DTOs.Posts;
using TechNews.Entity.Concrete;

namespace TechNews.Business.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IDataResult<PostDTO>> Add(PostCreateDTO postCreateDTO)
        {
            var createdPost = _mapper.Map<Post>(postCreateDTO);
            await _postRepository.Add(createdPost);
            var result = _mapper.Map<PostDTO>(createdPost);

            return new DataResult<PostDTO>(ResultStatus.Success, result);
        }

        public async Task<IResult> Delete(Guid id)
        {
            var post = await _postRepository.GetById(id);

            if (post == null)
            {
                return new Result(ResultStatus.Error, "Post not found.");
            }

            await _postRepository.Delete(post);

            return new Result(ResultStatus.Success, $"{post.Title} titled post deleted.");
        }

        public async Task<IDataResult<List<PostDTO>>> GetAll()
        {
            var posts = await _postRepository.GetAll();
            var postDtos = _mapper.Map<List<PostDTO>>(posts);

            return new DataResult<List<PostDTO>>(ResultStatus.Success, postDtos);
        }

        public async Task<IDataResult<List<PostDTO>>> GetAllByAuthorId(Guid id)
        {
            var posts = (await _postRepository.GetAll()).Where(x => x.AuthorId == id).ToList();

            if (!posts.Any())
            {
                return new DataResult<List<PostDTO>>(ResultStatus.Error, "There is no post from this author.", null);
            }

            var postDtos = _mapper.Map<List<PostDTO>>(posts);

            return new DataResult<List<PostDTO>>(ResultStatus.Success, postDtos);
        }

        public async Task<IDataResult<PostDTO>> GetById(Guid id)
        {
            var post = await _postRepository.GetById(id);

            if (post == null)
            {
                return new DataResult<PostDTO>(ResultStatus.Error, "Post not found.", null);
            }

            var postDto = _mapper.Map<PostDTO>(post);

            return new DataResult<PostDTO>(ResultStatus.Success, postDto);
        }

        public async Task<IDataResult<PostDTO>> Update(PostUpdateDTO postUpdateDTO)
        {
            var post = await _postRepository.GetById(postUpdateDTO.Id);
            var updatePost = _mapper.Map(postUpdateDTO, post);
            try
            {
                await _postRepository.Update(updatePost);
            }
            catch (Exception)
            {
                return new DataResult<PostDTO>(ResultStatus.Error, "Error occured when updating post. Are you missing property/properties ?", null);
            }

            var updatedPost = _mapper.Map<PostDTO>(updatePost);

            return new DataResult<PostDTO>(ResultStatus.Success, "Post successfully updated.", updatedPost);
            
        }
    }
}

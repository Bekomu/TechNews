using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.Result;
using TechNews.DTOs.Posts;

namespace TechNews.Business.Abstract
{
    public interface IPostService
    {
        Task<IDataResult<List<PostDTO>>> GetAll();
        Task<IDataResult<PostDTO>> GetById(Guid id);
        Task<IDataResult<PostDTO>> GetByAuthorId(Guid id);
        Task<IDataResult<PostDTO>> Add(PostCreateDTO postCreateDTO);
        Task<IDataResult<PostDTO>> Update(PostUpdateDTO postUpdateDTO);
        Task<IResult> Delete(Guid id);
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.DTOs.Posts;
using TechNews.Entity.Concrete;

namespace TechNews.Business.AutoMapper.Profiles
{
    public class PostProfile : Profile
    {
        public PostProfile()
        {
            CreateMap<PostDTO, Post>().ReverseMap();
            CreateMap<PostCreateDTO, Post>();
            CreateMap<PostUpdateDTO, Post>();
        }
    }
}

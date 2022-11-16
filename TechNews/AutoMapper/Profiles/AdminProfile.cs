using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Dtos.Admins;
using TechNews.Entity.Concrete;

namespace TechNews.Business.AutoMapper.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<AdminDTO, Admin>().ReverseMap();
            CreateMap<AdminCreateDTO, Admin>();
            CreateMap<AdminUpdateDTO, Admin>();
        }
    }
}

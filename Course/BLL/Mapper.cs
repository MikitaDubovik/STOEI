using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interface.Entities;
using DAL.Interface.DTO;

namespace BLL
{
    public static class Mapper
    {
        public static IMapper CreateMap()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<DalUser, BllUser>().ReverseMap();
                cfg.CreateMap<DalPost, BllPost>().ReverseMap();
                cfg.CreateMap<DalUserLikes, BllUserLikes>().ReverseMap();
                cfg.CreateMap<DalComment, BllComment>().ReverseMap();
            });

            return config.CreateMapper();
        }
    }
}

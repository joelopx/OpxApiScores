using ApiScoreBoard.Models;
using ApiScoreBoard.Resources.DtoModels;
using ApiScoreBoard.Resources.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.App_Start
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
        }

        protected override void Configure()
        {
            // Map Model to Dto
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<RequestModel, RequestModelDto>();

            CreateMap<ResponseModel,ResponseModelDto>();

            //Map Dto to Model
            CreateMap<UserDto,ApplicationUser>();
            CreateMap<RequestModelDto,RequestModel>();
            CreateMap<ResponseModelDto,ResponseModel>();
        }
    }
}
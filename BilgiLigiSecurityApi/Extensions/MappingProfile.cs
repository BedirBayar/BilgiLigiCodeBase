using AutoMapper;
using BilgiLigiSecurityApi.DTOs.UserModels;
using BilgiLigiSecurityApi.DTOs.RoleModels;
using BilgiLigiSecurityApi.DataLayer.Entities;

namespace BilgiLigiSecurityApi.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
        }
    }
}

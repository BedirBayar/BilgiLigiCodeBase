using AutoMapper;
using TriviaSecurityApi.DTOs.UserModels;
using TriviaSecurityApi.DTOs.RoleModels;
using TriviaSecurityApi.DataLayer.Entities;

namespace TriviaSecurityApi.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
        }
    }
}

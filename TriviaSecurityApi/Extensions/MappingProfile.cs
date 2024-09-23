using AutoMapper;
using TriviaSecurityApi.Entities;
using TriviaSecurityApi.DTOs.UserModels;
using TriviaSecurityApi.DTOs.RoleModels;

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

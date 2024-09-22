using AutoMapper;
using TriviaSecurityApi.Entities;
using TriviaSecurityApi.DTOs.UserModels;

namespace TriviaSecurityApi.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}

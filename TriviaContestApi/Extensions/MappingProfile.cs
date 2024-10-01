using AutoMapper;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}

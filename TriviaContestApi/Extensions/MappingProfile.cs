using AutoMapper;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DTOs;

namespace TriviaContestApi.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<ContestDto, Contest>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ContestRuleDto, ContestRule>().ReverseMap();
            CreateMap<ContestTypeDto, ContestType>().ReverseMap();
            CreateMap<LeaderBoardDto, LeaderBoard>().ReverseMap();
            CreateMap<QuestionDto, Question>().ReverseMap();
            CreateMap<UserMatchDto, UserMatch>().ReverseMap();
            CreateMap<TeamMatchDto, TeamMatch>().ReverseMap();
        }
    }
}

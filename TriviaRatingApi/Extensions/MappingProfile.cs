using AutoMapper;
using TriviaRatingApi.DataLayer.Entities;
using TriviaRatingApi.DataLayer.Relationships;
using TriviaRatingApi.DTOs;

namespace TriviaRatingApi.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile(){
            CreateMap<TeamDto, Team>().ReverseMap();
            CreateMap<AwardDto, Award>().ReverseMap();
            CreateMap<RankDto, Rank>().ReverseMap();
            CreateMap<UserRankDto, UserRank>().ReverseMap();
            CreateMap<TeamRankDto, TeamRank>().ReverseMap();
            CreateMap<UserRatingDto, UserRating>().ReverseMap();
            CreateMap<TeamRatingDto, TeamRating>().ReverseMap();
            CreateMap<UserAwardDto, UserAward>().ReverseMap();
            CreateMap<TeamAwardDto, TeamAward>().ReverseMap();
            CreateMap<UserTeamDto, UserTeam>().ReverseMap();
        }
    }
}

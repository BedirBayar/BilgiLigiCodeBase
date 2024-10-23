using AutoMapper;
using BilgiLigiRatingApi.DataLayer.Entities;
using BilgiLigiRatingApi.DataLayer.Relationships;
using BilgiLigiRatingApi.DTOs;

namespace BilgiLigiRatingApi.Extensions
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

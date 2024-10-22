using AutoMapper;
using TriviaContributionApi.DataLayer.Entities;
using TriviaContributionApi.DataLayer.Relationships;
using TriviaContributionApi.DTOs;

namespace TriviaContributionApi.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuestionDraftDto, QuestionDraft>().ReverseMap();
            CreateMap<QuestionDraftDifficultyDto, QuestionDraftDifficulty>().ReverseMap();
            CreateMap<QuestionDraftQualityDto, QuestionDraftQuality>().ReverseMap();
            CreateMap<QuestionDifficultyDto, QuestionDifficulty>().ReverseMap();
            CreateMap<QuestionQualityDto, QuestionQuality>().ReverseMap();
            CreateMap<UserContributionRatingDto, UserContributionRating>().ReverseMap();
        }
    }
}

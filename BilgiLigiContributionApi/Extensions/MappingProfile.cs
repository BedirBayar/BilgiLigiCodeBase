using AutoMapper;
using BilgiLigiContributionApi.DataLayer.Entities;
using BilgiLigiContributionApi.DataLayer.Relationships;
using BilgiLigiContributionApi.DTOs;

namespace BilgiLigiContributionApi.Extensions
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

using System.ComponentModel.DataAnnotations;

namespace TriviaContributionApi.DTOs
{
    public class UserContributionRatingDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public decimal ContributionRating { get; set; }
    }
}

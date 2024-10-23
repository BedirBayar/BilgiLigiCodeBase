using System.ComponentModel.DataAnnotations;

namespace TriviaRatingApi.Models.TeamModels
{
    public class AddTeamAwardRequest
    {
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int AwardId { get; set; }
    }
}

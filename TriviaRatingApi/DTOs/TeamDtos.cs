using System.ComponentModel.DataAnnotations;

namespace TriviaRatingApi.DTOs
{
    public class TeamRankDto
    {
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int RankDegree { get; set; }
    }
    public class TeamRatingDto
    {
        [Required]
        public int TeamId { get; set; }
        [Required]
        public decimal Rating { get; set; }
    }
    public class TeamAwardDto
    {
        public int Id { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int AwardId { get; set; }
    }
}

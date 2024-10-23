using System.ComponentModel.DataAnnotations;

namespace BilgiLigiRatingApi.DTOs
{
    public class UserRankDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RankDegree { get; set;}
    }
    public class UserRatingDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public decimal Rating { get; set; }
    }
    public class UserAwardDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AwardId { get; set; }
    }
    public class UserTeamDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int TeamId { get; set; }
    }
}

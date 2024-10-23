using System.ComponentModel.DataAnnotations;

namespace BilgiLigiRatingApi.Models.UserModels
{
    public class AddUserAwardRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int AwardId { get; set; }
    }
    public class AddUserRankRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RankDegree { get; set; }
    }
}

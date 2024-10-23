using System.ComponentModel.DataAnnotations;

namespace BilgiLigiRatingApi.DTOs
{
    public class AwardDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Badge { get; set; }
        public string UserOrTeam { get; set; } = "U";
        public bool IsActive { get; set; }
    }
}

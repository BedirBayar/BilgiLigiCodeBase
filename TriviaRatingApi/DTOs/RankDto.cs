using System.ComponentModel.DataAnnotations;

namespace TriviaRatingApi.DTOs
{
    public class RankDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Degree { get; set; }
        [Required]
        public string Description { get; set; }
        public string Insignia { get; set; }
        public string UserOrTeam { get; set; } = "U";
        public bool IsActive { get; set; }
    }
}

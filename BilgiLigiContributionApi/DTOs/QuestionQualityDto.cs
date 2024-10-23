using System.ComponentModel.DataAnnotations;

namespace BilgiLigiContributionApi.DTOs
{
    public class QuestionQualityDto
    {
        public int Id { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int QualityPoint { get; set; }
        [Required]
        public string Feedback { get; set; }
    }
    public class QuestionDifficultyDto
    {
        public int Id { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int DifficultyPoint { get; set; }
    }
    
}

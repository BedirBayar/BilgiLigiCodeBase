using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContributionApi.DTOs
{
    public class QuestionDraftQualityDto
    {
        public int Id { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int QuestionDraftId { get; set; }
        [Required]
        public int QualityPoint { get; set; }
        public string Feedback { get; set; }
        
    }
    public class QuestionDraftDifficultyDto
    {
        public int Id { get; set; }
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public int QuestionDraftId { get; set; }
        [Required]
        public int DifficultyPoint { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContributionApi.DTOs
{
    public class QuestionDraftQualityDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int QuestionDraftId { get; set; }
        public int QualityPoint { get; set; }
        public string Feedback { get; set; }
        
    }
    public class QuestionDraftDifficultyDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int QuestionDraftId { get; set; }
        public int DifficultyPoint { get; set; }
    }
}

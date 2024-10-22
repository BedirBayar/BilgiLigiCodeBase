namespace TriviaContributionApi.DTOs
{
    public class QuestionQualityDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int QuestionId { get; set; }
        public int QualityPoint { get; set; }
        public string Feedback { get; set; }
    }
    public class QuestionDifficultyDto
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public int QuestionId { get; set; }
        public int DifficultyPoint { get; set; }
    }
    
}

namespace TriviaContributionApi.DTOs
{
    public class QuestionDraftDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int Difficulty { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Answer { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public bool IsActive { get; set; }
    }
}

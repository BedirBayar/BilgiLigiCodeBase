using System.ComponentModel.DataAnnotations;

namespace BilgiLigiContributionApi.DTOs
{
    public class QuestionDraftDto
    {
        public int Id { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int Difficulty { get; set; }
        [Required]
        public string Text { get; set; }
        public string Image { get; set; }
        [Required]
        public string Answer { get; set; }
        [Required]
        public string Choice1 { get; set; }
        [Required]
        public string Choice2 { get; set; }
        [Required]
        public string Choice3 { get; set; }
        [Required]
        public string Choice4 { get; set; }
        public bool IsActive { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TriviaContributionApi.DataLayer.Entities;

namespace TriviaContributionApi.DataLayer.Relationships
{
    [Table("QuestionDraftQuality")]
    public class QuestionDraftQuality :BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("QuestionDraftId")]
        public int QuestionDraftId { get; set; }
        [Column("QualityPoint")]
        public int QualityPoint { get; set; }
        [Column("Feedback")]
        public string Feedback { get; set; }
    }
}

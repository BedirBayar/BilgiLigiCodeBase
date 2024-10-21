using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TriviaContributionApi.DataLayer.Entities;

namespace TriviaContributionApi.DataLayer.Relationships
{
    [Table("QuestionDraftDifficulty")]
    public class QuestionDraftDifficulty:BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("QuestionDraftId")]
        public int QuestionDraftId { get; set; }
        [Column("DifficultyPoint")]
        public int DifficultyPoint { get; set; }
    }
}

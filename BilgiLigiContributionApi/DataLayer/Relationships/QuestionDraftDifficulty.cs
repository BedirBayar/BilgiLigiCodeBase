using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BilgiLigiContributionApi.DataLayer.Entities;

namespace BilgiLigiContributionApi.DataLayer.Relationships
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

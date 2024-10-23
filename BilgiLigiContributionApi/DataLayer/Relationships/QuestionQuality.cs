using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BilgiLigiContributionApi.DataLayer.Entities;

namespace BilgiLigiContributionApi.DataLayer.Relationships
{
    [Table("QuestionQuality")]
    public class QuestionQuality :BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("QuestionId")]
        public int QuestionId { get; set; }
        [Column("QualityPoint")]
        public int QualityPoint { get; set; }
        [Column("Feedback")]
        public string Feedback { get; set; }
    }
}

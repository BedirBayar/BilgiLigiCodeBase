using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BilgiLigiContestApi.DataAccess.Relationships
{
    
    public class TeamMatchQuestion
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("TeamMatchId")]
        public int TeamMatchId { get; set; }
        [Column("QuestionId")]
        public int QuestionId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TriviaContestApi.DataAccess.Relationships
{
    
    public class TeamMatchQuestion
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("MatchId")]
        public int TeamMatchId { get; set; }
        [Column("QuestionId")]
        public int QuestionId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Relationships
{
    public class MatchQuestion
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("MatchId")]
        public int MatchId { get; set; }
        [Column("QuestionId")]
        public int QuestionId { get; set; }

    }
}

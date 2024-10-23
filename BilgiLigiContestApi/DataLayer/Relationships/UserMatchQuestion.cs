using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContestApi.DataAccess.Relationships
{
    public class UserMatchQuestion
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("UserMatchId")]
        public int UserMatchId { get; set; }
        [Column("QuestionId")]
        public int QuestionId { get; set; }
    }
}

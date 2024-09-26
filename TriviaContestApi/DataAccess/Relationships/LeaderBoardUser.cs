using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TriviaContestApi.DataAccess.Relationships
{
    public class LeaderBoardUser
    {
        
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("LeaderBoardId")]
        public int LeaderBoardId { get; set; }
        [Column("TeamId")]
        public int UserId { get; set; }
        [Column("Points")]
        public int Points { get; set; }
        
    }
}

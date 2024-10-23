using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContestApi.DataAccess.Relationships
{
    public class LeaderBoardTeam
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("LeaderBoardId")]
        public int LeaderBoardId { get; set; }
        [Column("TeamId")]
        public int TeamId { get; set; }
        [Column("Points")]
        public int Points { get; set; }
    }
}

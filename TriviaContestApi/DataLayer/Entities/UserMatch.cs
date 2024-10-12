using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class UserMatch :BaseMatch
    {
        [Column("User1Id")]
        public int User1Id { get; set; }
        [Column("User1Score")]
        public int User1Score { get; set; }
        [Column("User2Id")]
        public int User2Id { get; set; }
        [Column("User2Score")]
        public int User2Score { get; set; }
    }
 
}

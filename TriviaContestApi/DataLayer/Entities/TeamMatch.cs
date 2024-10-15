using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
  
    public class TeamMatch : BaseMatch
    {
        [Column("Team1Id")]
        public int Team1Id { get; set; }
        [Column("Team1Score")]
        public int Team1Score { get; set; }
        [Column("Team2Id")]
        public int Team2Id { get; set; }
        [Column("Team2Score")]
        public int Team2Score { get; set; }
    }
}

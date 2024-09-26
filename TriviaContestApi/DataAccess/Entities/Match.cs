using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class Match : BaseEntity
    {
        [Column("StartDate")]
        public DateTime StartDate { get; set; }
        [Column("EndDate")]
        public DateTime EndDate { get; set; }
        [Column("User1Id")]
        public int User1Id { get; set; }
        [Column("User2Id")]
        public int User2Id { get; set; }
        [Column("Team1Id")]
        public int Team1Id { get; set; }
        [Column("Team2Id")]
        public int Team2Id { get; set; }
        [Column("IsTeamMatch")]
        public bool IsTeamMatch { get; set; }
        [Column("IsLeagueMatch")]
        public bool IsLeagueMatch { get; set; }
        [Column("ContestId")]
        public int ContestId { get; set; }

    }
}

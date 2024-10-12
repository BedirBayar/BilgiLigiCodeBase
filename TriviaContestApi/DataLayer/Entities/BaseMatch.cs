using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class BaseMatch : BaseEntity
    {
        [Column("StartDate")]
        public DateTime StartDate { get; set; }
        [Column("EndDate")]
        public DateTime EndDate { get; set; }
      
        [Column("IsTeamMatch")]
        public bool IsTeamMatch { get; set; }
        [Column("IsLeagueMatch")]
        public bool IsLeagueMatch { get; set; }
        [Column("ContestId")]
        public int ContestId { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class LeaderBoard : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("IsComplete")]
        public bool IsComplete { get; set; }
        [Column("IsTeamLeaderBoard")]
        public bool IsTeamLeaderBoard { get; set; }
        [Column("Notes")]
        public string Notes { get; set; }
    }
}

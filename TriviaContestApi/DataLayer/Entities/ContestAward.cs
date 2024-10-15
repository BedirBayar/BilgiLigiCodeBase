using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class ContestAward : BaseEntity
    {

        [Column("ContestId")]
        public int ContestId { get; set; }
        [Column("LeaderBoardRank")]
        public int LeaderBoardRank { get; set; }
        [Column("AwardRating")]
        public int AwardRating { get; set; } = 0;
        [Column("AwardId")]
        public int AwardId { get; set; }
    }
}

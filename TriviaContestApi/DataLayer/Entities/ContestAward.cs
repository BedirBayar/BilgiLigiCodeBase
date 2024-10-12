using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class ContestAward : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("LeaderBoardRank")]
        public int LeaderBoardRank { get; set; }
        [Column("AwardRating")]
        public int AwardRating { get; set; }
        [Column("AwardId")]
        public int AwardId { get; set; }
    }
}

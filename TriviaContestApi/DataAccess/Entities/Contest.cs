using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DataAccess.Entities
{
    public class Contest : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("PrizeRating")]
        public decimal PrizeRating { get; set; }
        [Column("StartDate")]
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        [Column("EndDate")]
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        [Column("ContestTypeId")]
        public int ContestTypeId { get; set; }
        [Column("MinimumRank")]
        public int MinimumRank { get; set; }
        [Column("MaximumRank")]
        public int MaximumRank { get; set; }
        [Column("LeaderBoardId")]
        public int LeaderBoardId { get; set; }

    }
}

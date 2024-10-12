using System.ComponentModel.DataAnnotations.Schema;
using TriviaContestApi.Models;

namespace TriviaContestApi.DataAccess.Entities
{
    public class Contest : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
        [Column("PrizeRating")]
        public decimal PrizeRating { get; set; } = 0;
        [Column("AwardId")]
        public int AwardId { get; set; } = 0;
        [Column("StartDate")]
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        [Column("EndDate")]
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        [Column("ContestTypeId")]
        public int ContestTypeId { get; set; }
        [Column("MinimumRank")]
        public int MinimumRank { get; set; }
        [Column("ContestantNumber")]
        public int ContestantNumber { get; set; }
        [Column("MatchFrequency")]
        public int MatchFrequency { get; set; }
        [Column("IsPeriodic")]
        public bool IsPeriodic { get; set; }
        [Column("IsRunning")]
        public bool IsRunning { get; set; }
        [Column("PeriodType")]
        public string PeriodType { get; set; } = PeriodTypes.Once;
        [Column("MaximumRank")]
        public int MaximumRank { get; set; }
        [Column("LeaderBoardId")]
        public int LeaderBoardId { get; set; }

    }
}

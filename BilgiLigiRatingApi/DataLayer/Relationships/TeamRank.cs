using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiRatingApi.DataLayer.Relationships
{
    [Table("TeamRank")]
    public class TeamRank
    {
        [Key]
        [Column("TeamId")]
        public int TeamId { get; set; }
        [Column("RankDegree")]
        public int RankDegree { get; set; }

    }
    [Table("TeamRating")]
    public class TeamRating
    {
        [Key]
        [Column("TeamId")]
        public int TeamId { get; set; }
        [Column("Rating")]
        public decimal Rating { get; set; }

    }
    [Table("TeamAward")]
    public class TeamAward
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("TeamId")]
        public int TeamId { get; set; }
        [Column("AwardId")]
        public int AwardId { get; set; }

    }
}

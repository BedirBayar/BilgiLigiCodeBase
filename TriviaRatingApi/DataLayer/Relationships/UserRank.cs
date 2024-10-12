using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaRatingApi.DataLayer.Relationships
{
    [Table("UserRank")]
    public class UserRank
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("RankDegree")]
        public int RankDegree { get; set; }
    }

    [Table("UserRating")]
    public class UserRating
    {
        [Key]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("RankDegree")]
        public decimal Rating { get; set; }
    }
    [Table("UserAward")]
    public class UserAward
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("AwardId")]
        public int AwardId { get; set; }
    }
}

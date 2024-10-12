using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaRatingApi.DataLayer.Relationships
{
    [Table("UserTeam")]
    public class UserTeam
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("TeamId")]
        public int TeamId { get; set; }
    }
}

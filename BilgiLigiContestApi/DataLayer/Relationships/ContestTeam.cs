using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContestApi.DataAccess.Relationships
{
    public class ContestTeam
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ContestId")]
        public int ContestId { get; set; }
        [Column("TeamId")]
        public int TeamId { get; set; }
    }
}

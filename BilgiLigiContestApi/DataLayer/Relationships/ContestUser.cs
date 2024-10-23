using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContestApi.DataLayer.Relationships
{
    [Table("ContestUser")]
    public class ContestUser
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ContestId")]
        public int ContestId { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
    }
}

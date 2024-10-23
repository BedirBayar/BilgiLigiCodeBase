using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContributionApi.DataLayer.Relationships
{
    [Table("UserContributionRating")]
    public class UserContributionRating
    {
        [Key] [Required]
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("ContributionRating")]
        public decimal ContributionRating { get; set; }
    }
}

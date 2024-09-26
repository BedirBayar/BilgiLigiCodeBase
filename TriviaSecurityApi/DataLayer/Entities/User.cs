using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaSecurityApi.DataLayer.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        [Column("Email")]
        public string? Email { get; set; }

        [Column("UserName")]
        public string? UserName { get; set; }

        [Column("Phone")]
        public string? Phone { get; set; }

        [Column("Password")]
        public string? Password { get; set; }

        [Column("PasswordHash")]
        public string? PasswordHash { get; set; }

        [Column("SecurityStamp")]
        public string? SecurityStamp { get; set; }

        [Column("RoleId")]
        public int RoleId { get; set; }

        [Column("RankId")]
        public int RankId { get; set; }

        [Column("Rating")]
        public decimal Rating { get; set; }

        [Column("ContributionRating")]
        public decimal ContributionRating { get; set; }

        [Column("ReportedRating")]
        public int ReportedRating { get; set; }

        [Column("IsBanned")]
        public bool IsBanned { get; set; }

        [Column("IsEmailConfirmed")]
        public bool IsEmailConfirmed { get; set; }

        [Column("BanReason")]
        public string? BanReason { get; set; }

        [Column("BannedUntil")]
        public DateTime? BannedUntil { get; set; }

        [Column("Avatar")]
        public string? Avatar { get; set; }

    }
}

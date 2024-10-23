using System.ComponentModel.DataAnnotations;

namespace TriviaSecurityApi.DTOs.UserModels
{
    public class BanUserRequest
    {
        [Required]
        public int UserId { get; set; }
        public bool IsUnbanRequest { get; set; }
        [Required]
        public string BanReason { get; set; }
        [Required]
        public int BanDays { get; set; }
    }
}

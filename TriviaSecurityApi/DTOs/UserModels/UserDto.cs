using System.ComponentModel.DataAnnotations;

namespace TriviaSecurityApi.DTOs.UserModels
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Avatar { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}

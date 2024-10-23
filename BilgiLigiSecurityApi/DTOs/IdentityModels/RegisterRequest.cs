using System.ComponentModel.DataAnnotations;

namespace BilgiLigiSecurityApi.DTOs.IdentityModels
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [MinLength(10)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Avatar { get; set; }

    }
}

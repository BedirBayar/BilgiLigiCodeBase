using System.ComponentModel.DataAnnotations;
using BilgiLigiSecurityApi.Extensions.Attributes;

namespace BilgiLigiSecurityApi.DTOs.IdentityModels
{
    public class TokenRequest
    {
        [AtLeastOneRequired("UserName")]
        public string Email { get; set; }
        [AtLeastOneRequired("Email")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }

    
}

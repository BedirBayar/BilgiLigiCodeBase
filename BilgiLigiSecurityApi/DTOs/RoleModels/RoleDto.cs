using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiSecurityApi.DTOs.RoleModels
{
    public class RoleDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}

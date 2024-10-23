using System.ComponentModel.DataAnnotations;

namespace BilgiLigiContestApi.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContestApi.DTOs
{
    public class ContestRuleDto
    {
        public int Id { get; set; }
        [Required]
        public int ContestTypeId { get; set; }
        [Required]
        public int Order { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace TriviaContestApi.DTOs
{
    public class ContestRuleDto
    {
        public int Id { get; set; }
        public int ContestTypeId { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}

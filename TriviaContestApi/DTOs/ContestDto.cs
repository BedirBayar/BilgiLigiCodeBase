using System.ComponentModel.DataAnnotations;
using TriviaContestApi.Models;

namespace TriviaContestApi.DTOs
{
    public class ContestDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue; 
        [Required]
        public int ContestTypeId { get; set; }
        public int MinimumRank { get; set; }
        public int MaximumRank { get; set; }
        [Required]
        public int ContestantNumber { get; set; }
        public int MatchFrequency { get; set; }
        public string PeriodType { get; set; } = PeriodTypes.Once;
        public bool IsActive { get; set; }
        public bool IsPeriodic { get; set; }
        public bool IsRunning { get; set; }
        public List<ContestAwardDto> Awards { get; set; }
    }
}

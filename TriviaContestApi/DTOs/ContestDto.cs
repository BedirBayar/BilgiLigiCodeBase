using TriviaContestApi.Models;

namespace TriviaContestApi.DTOs
{
    public class ContestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public int ContestTypeId { get; set; }
        public int MinimumRank { get; set; }
        public int MaximumRank { get; set; }
        public int ContestantNumber { get; set; }
        public int MatchFrequency { get; set; }
        public string PeriodType { get; set; } = PeriodTypes.Once;
        public bool IsActive { get; set; }
        public bool IsPeriodic { get; set; }
        public bool IsRunning { get; set; }
    }
}

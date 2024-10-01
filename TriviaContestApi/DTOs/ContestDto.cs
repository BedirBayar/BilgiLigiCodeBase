namespace TriviaContestApi.DTOs
{
    public class ContestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PrizeRating { get; set; } = 0;
        public DateTime StartDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.MinValue;
        public int ContestTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsRunning { get; set; }
    }
}

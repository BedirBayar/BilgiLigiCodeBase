namespace TriviaRatingApi.DTOs
{
    public class TeamRankDto
    {
        public int TeamId { get; set; }
        public int RankDegree { get; set; }
    }
    public class TeamRatingDto
    {
        public int TeamId { get; set; }
        public decimal Rating { get; set; }
    }
    public class TeamAwardDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int AwardId { get; set; }
    }
}

namespace TriviaRatingApi.DTOs
{
    public class UserRankDto
    {
        public int UserId { get; set;}
        public int RankDegree { get; set;}
    }
    public class UserRatingDto
    {
        public int UserId { get; set; }
        public decimal Rating { get; set; }
    }
    public class UserAwardDto
    {
        public int UserId { get; set; }
        public int AwardId { get; set; }
    }
    public class UserTeamDto
    {
        public int UserId { get; set; }
        public int TeamId { get; set; }
    }
}

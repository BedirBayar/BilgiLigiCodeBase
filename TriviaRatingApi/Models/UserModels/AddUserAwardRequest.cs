namespace TriviaRatingApi.Models.UserModels
{
    public class AddUserAwardRequest
    {
        public int UserId { get; set; }
        public int AwardId { get; set; }
    }
    public class AddUserRankRequest
    {
        public int UserId { get; set; }
        public int RankDegree { get; set; }
    }
}

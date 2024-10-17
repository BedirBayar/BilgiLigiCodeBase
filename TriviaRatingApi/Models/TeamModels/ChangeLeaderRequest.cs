namespace TriviaRatingApi.Models.TeamModels
{
    public class ChangeLeaderRequest
    {
        public int TeamId   { get; set; }
        public int NewLeaderId { get; set; }

    }
}

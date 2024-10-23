namespace BilgiLigiContestApi.Models.ContestModels
{
    public class RegisterUserToContestRequest
    {
        public int ContestId { get; set; }
        public int UserId { get; set; }
        public int UserRank { get; set; }
    }
    public class RegisterTeamToContestRequest
    {
        public int ContestId { get; set; }
        public int TeamId { get; set; }
        public int TeamRank { get; set; }
    }
}

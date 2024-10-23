using System.ComponentModel.DataAnnotations.Schema;

namespace BilgiLigiContestApi.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsTeamMatch { get; set; }
        public bool IsLeagueMatch { get; set; }
        public int ContestId { get; set; }
    }
    public class UserMatchDto :MatchDto
    {
        public int User1Id { get; set; }
        public int User1Score { get; set; }
        public int User2Id { get; set; }
        public int User2Score { get; set; }
    }
    public class TeamMatchDto: MatchDto
    {
        public int Team1Id { get; set; }
        public int Team1Score { get; set; }
        public int Team2Id { get; set; }
        public int Team2Score { get; set; }
    }
}

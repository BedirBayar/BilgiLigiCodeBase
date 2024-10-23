using System.ComponentModel.DataAnnotations;

namespace BilgiLigiContestApi.DTOs
{
    public class LeaderBoardDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public bool IsTeamLeaderBoard { get; set; }
        public string Notes { get; set; }
    }
}

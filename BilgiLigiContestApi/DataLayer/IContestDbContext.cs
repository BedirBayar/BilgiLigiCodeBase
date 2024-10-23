using Microsoft.EntityFrameworkCore;
using BilgiLigiContestApi.DataAccess.Entities;
using BilgiLigiContestApi.DataAccess.Relationships;
using BilgiLigiContestApi.DataLayer.Relationships;

namespace BilgiLigiContestApi.DataAccess
{
    public interface IContestDbContext
    {
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<UserMatch> UserMatches { get; set; }
        public DbSet<TeamMatch> TeamMatches { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ContestAward> ContestAwards { get; set; }
        public DbSet<ContestType> ContestTypes { get; set; }
        public DbSet<ContestRule> ContestRules { get; set; }
        public DbSet<ContestTeam> ContestTeams { get; set; }
        public DbSet<ContestUser> ContestUsers { get; set; }
        public DbSet<LeaderBoardTeam> LeaderBoardTeams { get; set; }
        public DbSet<LeaderBoardUser> LeaderBoardUsers { get; set; }
        public DbSet<UserMatchQuestion> UserMatchQuestions { get; set; }
        public DbSet<TeamMatchQuestion> TeamMatchQuestions { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

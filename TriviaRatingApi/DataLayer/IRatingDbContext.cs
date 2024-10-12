using Microsoft.EntityFrameworkCore;
using TriviaRatingApi.DataLayer.Entities;
using TriviaRatingApi.DataLayer.Relationships;

namespace TriviaRatingApi.DataLayer
{
    public interface IRatingDbContext
    {
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<UserRank> UserRanks { get; set; }
        public DbSet<TeamRank> TeamRanks { get; set; }
        public DbSet<UserRating> UserRatings { get; set; }
        public DbSet<TeamRating> TeamRatings { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<UserAward> UserAwards { get; set; }
        public DbSet<TeamAward> TeamAwards { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

using Microsoft.EntityFrameworkCore;
using BilgiLigiRatingApi.DataLayer.Entities;
using BilgiLigiRatingApi.DataLayer.Relationships;

namespace BilgiLigiRatingApi.DataLayer
{
    public class RatingDbContext : DbContext, IRatingDbContext
    {
        public RatingDbContext(DbContextOptions<RatingDbContext> options) : base(options)
        {
        }

        // DbSets for the tables
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //QueryFilters
            modelBuilder.Entity<Rank>().HasQueryFilter(e => !e.IsArchived);
            modelBuilder.Entity<Award>().HasQueryFilter(e =>  !e.IsArchived);
            modelBuilder.Entity<Team>().HasQueryFilter(e =>  !e.IsArchived);
            //

            // Rank entity configuration
            modelBuilder.Entity<Rank>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
                entity.Property(r => r.Degree).IsRequired();
                entity.Property(r => r.UserOrTeam).IsRequired().HasMaxLength(1);
            });

            // Award entity configuration
            modelBuilder.Entity<Award>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
                entity.Property(a => a.UserOrTeam).IsRequired().HasMaxLength(1);
            });

            // Team entity configuration
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
                entity.Property(t => t.IsBanned).HasDefaultValue(false);
                entity.Property(t => t.BannedUntil).HasColumnType("datetime");
            });

            // UserRank entity configuration
            modelBuilder.Entity<UserRank>(entity =>
            {
                entity.HasKey(ur =>  ur.UserId);
                entity.Property(ur => ur.RankDegree).IsRequired();
            });

            // TeamRank entity configuration
            modelBuilder.Entity<TeamRank>(entity =>
            {
                entity.HasKey(tr => new { tr.TeamId, tr.RankDegree });
                entity.Property(tr => tr.RankDegree).IsRequired();
            });

            // UserRating entity configuration
            modelBuilder.Entity<UserRating>(entity =>
            {
                entity.HasKey(ur => ur.UserId);
                entity.Property(ur => ur.Rating).IsRequired();
            });

            // TeamRating entity configuration
            modelBuilder.Entity<TeamRating>(entity =>
            {
                entity.HasKey(tr => tr.TeamId);
                entity.Property(tr => tr.Rating).IsRequired();
            });

            // UserTeam entity configuration
            modelBuilder.Entity<UserTeam>(entity =>
            {
                entity.HasKey(ut => new { ut.UserId, ut.TeamId });
            });

            // UserAward entity configuration
            modelBuilder.Entity<UserAward>(entity =>
            {
                entity.HasKey(ua => ua.Id);
                entity.HasIndex(ua => new { ua.UserId, ua.AwardId });
            });

            // TeamAward entity configuration
            modelBuilder.Entity<TeamAward>(entity =>
            {
                entity.HasKey(ta => ta.Id);
                entity.HasIndex(ta => new { ta.TeamId, ta.AwardId });
            });

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            return await base.SaveChangesAsync(cancellationToken);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess.Entities;
using TriviaContestApi.DataAccess.Relationships;

namespace TriviaContestApi.DataAccess
{
    public class ContestDbContext :DbContext, IContestDbContext
    {
        public ContestDbContext(DbContextOptions<ContestDbContext> options) : base(options)
        {

        }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LeaderBoard> LeaderBoards { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ContestAward> ContestAwards { get; set; }
        public DbSet<ContestType> ContestTypes { get; set; }
        public DbSet<ContestRule> ContestRules { get; set; }
        public DbSet<ContestTeam> ContestTeams { get; set; }
        public DbSet<LeaderBoardTeam> LeaderBoardTeams { get; set; }
        public DbSet<LeaderBoardUser> LeaderBoardUsers { get; set; }
        public DbSet<MatchQuestion> MatchQuestions { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text).IsRequired().HasMaxLength(1000);
                entity.Property(e => e.Image).HasMaxLength(255);
                entity.Property(e => e.Answer).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Choice1).HasMaxLength(255);
                entity.Property(e => e.Choice2).HasMaxLength(255);
                entity.Property(e => e.Choice3).HasMaxLength(255);
                entity.Property(e => e.Choice4).HasMaxLength(255);

                entity.HasOne<Category>()  // Reference to Category table in another DB
                    .WithMany()
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Contest>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.PrizeRating).HasColumnType("decimal(18,2)");
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.MinimumRank).IsRequired();
                entity.Property(e => e.MaximumRank).IsRequired();

                entity.HasOne<ContestType>()  // ContestType reference from another DB
                    .WithMany()
                    .HasForeignKey(e => e.ContestTypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<LeaderBoard>()  // LeaderBoard reference from another DB
                    .WithMany()
                    .HasForeignKey(e => e.LeaderBoardId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ContestAward>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.LeaderBoardRank).IsRequired();
                entity.Property(e => e.AwardRating).IsRequired();

               
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.IsTeamMatch).IsRequired();
                entity.Property(e => e.IsLeagueMatch).IsRequired();

                entity.HasOne<Contest>()  // Contest reference from another DB
                    .WithMany()
                    .HasForeignKey(e => e.ContestId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<LeaderBoardTeam>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne<LeaderBoard>()  // LeaderBoard reference
                    .WithMany()
                    .HasForeignKey(e => e.LeaderBoardId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Points).IsRequired();
            });

            modelBuilder.Entity<LeaderBoardUser>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne<LeaderBoard>()  // LeaderBoard reference
                    .WithMany()
                    .HasForeignKey(e => e.LeaderBoardId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(e => e.Points).IsRequired();
            });

            modelBuilder.Entity<ContestType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<ContestRule>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Order).IsRequired();

                entity.HasOne<ContestType>()  // ContestType reference from another DB
                    .WithMany()
                    .HasForeignKey(e => e.ContestTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<ContestTeam>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne<Contest>()  // Contest reference
                    .WithMany()
                    .HasForeignKey(e => e.ContestId)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<MatchQuestion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne<Match>()  // Match reference
                    .WithMany()
                    .HasForeignKey(e => e.MatchId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne<Question>()  // Question reference from another DB
                    .WithMany()
                    .HasForeignKey(e => e.QuestionId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            return await base.SaveChangesAsync(cancellationToken);

        }
    }
}

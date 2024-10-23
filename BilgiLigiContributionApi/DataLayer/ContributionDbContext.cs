using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BilgiLigiContributionApi.DataLayer.Entities;
using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer
{
    public class ContributionDbContext : DbContext, IContributionDbContext
    {
        public ContributionDbContext(DbContextOptions<ContributionDbContext> options) : base(options)
        {

        }
        public DbSet<QuestionDraft> QuestionDrafts { get; set; }

        public DbSet<QuestionDifficulty> QuestionDifficulties { get; set; }

        public DbSet<QuestionQuality> QuestionQualities { get; set; }

        public DbSet<QuestionDraftDifficulty> QuestionDraftDifficulties { get; set; }

        public DbSet<QuestionDraftQuality> QuestionDraftQualities { get; set; }

        public DbSet<UserContributionRating> UserContributionRatings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //QueryFilters
            modelBuilder.Entity<QuestionDraft>().HasQueryFilter(e => !e.IsArchived);
            modelBuilder.Entity<QuestionDraftQuality>().HasQueryFilter(e => !e.IsArchived);
            modelBuilder.Entity<QuestionDraftDifficulty>().HasQueryFilter(e => !e.IsArchived);
            modelBuilder.Entity<QuestionQuality>().HasQueryFilter(e => !e.IsArchived);
            modelBuilder.Entity<QuestionDifficulty>().HasQueryFilter(e => !e.IsArchived);

            // QuestionDraft Configuration
            modelBuilder.Entity<QuestionDraft>(entity =>
            {
                entity.HasKey(e => e.Id);  // Primary key
                entity.Property(e => e.Text).IsRequired().HasMaxLength(500);
                entity.Property(e => e.Difficulty).IsRequired();
            });

            // QuestionDraftDifficulty Configuration
            modelBuilder.Entity<QuestionDraftDifficulty>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.DifficultyPoint).IsRequired();

                // Foreign key to QuestionDraft
                entity.HasOne<QuestionDraft>()
                      .WithMany()
                      .HasForeignKey(e => e.QuestionDraftId)
                      .OnDelete(DeleteBehavior.Cascade);  // If a QuestionDraft is deleted, its difficulties are also deleted
            });

            // QuestionDraftQuality Configuration
            modelBuilder.Entity<QuestionDraftQuality>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.QualityPoint).IsRequired();

                // Foreign key to QuestionDraft
                entity.HasOne<QuestionDraft>()
                      .WithMany()
                      .HasForeignKey(e => e.QuestionDraftId)
                      .OnDelete(DeleteBehavior.Cascade);  // If a QuestionDraft is deleted, its qualities are also deleted
            });

            // QuestionDifficulty Configuration
            modelBuilder.Entity<QuestionDifficulty>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.QuestionId).IsRequired();
                entity.Property(e => e.DifficultyPoint).IsRequired();

            });

            // QuestionQuality Configuration
            modelBuilder.Entity<QuestionQuality>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.QuestionId).IsRequired();
                entity.Property(e => e.QualityPoint).IsRequired();

            });

            // UserContributionRating Configuration
            modelBuilder.Entity<UserContributionRating>(entity =>
            {
                entity.HasKey(e => e.UserId);  // Primary key is UserId
                entity.Property(e => e.ContributionRating).IsRequired();
            });

        }
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

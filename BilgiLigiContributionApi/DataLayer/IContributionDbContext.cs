using Microsoft.EntityFrameworkCore;
using BilgiLigiContributionApi.DataLayer.Entities;
using BilgiLigiContributionApi.DataLayer.Relationships;

namespace BilgiLigiContributionApi.DataLayer
{
    public interface IContributionDbContext
    {
        public DbSet<QuestionDraft> QuestionDrafts { get; set; }
        public DbSet<QuestionDifficulty> QuestionDifficulties { get; set; }
        public DbSet<QuestionQuality> QuestionQualities { get; set; }
        public DbSet<QuestionDraftDifficulty> QuestionDraftDifficulties { get; set; }
        public DbSet<QuestionDraftQuality> QuestionDraftQualities { get; set; }
        public DbSet<UserContributionRating> UserContributionRatings { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

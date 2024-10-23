using Microsoft.EntityFrameworkCore;
using BilgiLigiContributionApi.DataLayer;
using BilgiLigiContributionApi.DataLayer.Repositories.QuestionDifficulty_;
using BilgiLigiContributionApi.DataLayer.Repositories.QuestionDraft_;
using BilgiLigiContributionApi.DataLayer.Repositories.QuestionDraftDifficulty_;
using BilgiLigiContributionApi.DataLayer.Repositories.QuestionDraftQuality_;
using BilgiLigiContributionApi.DataLayer.Repositories.QuestionQuality_;
using BilgiLigiContributionApi.DataLayer.Repositories.UserContributionRating_;
using BilgiLigiContributionApi.Services;

namespace BilgiLigiContributionApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // data layer
            services.AddScoped<IContributionDbContext, ContributionDbContext>();
            services.AddScoped<IQuestionDraftRepository, QuestionDraftRepository>();
            services.AddScoped<IQuestionDifficultyRepository, QuestionDifficultyRepository>();
            services.AddScoped<IQuestionQualityRepository, QuestionQualityRepository>();
            services.AddScoped<IDraftDifficultyRepository, DraftDifficultyRepository>();
            services.AddScoped<IDraftQualityRepository, DraftQualityRepository>();
            services.AddScoped<IUserContributionRatingRepository, UserContributionRatingRepository>();
            //service layer
            services.AddScoped<QuestionDraftService>();
            services.AddScoped<DraftQualityService>();
            services.AddScoped<DraftDifficultyService>();
            services.AddScoped<QuestionQualityService>();
            services.AddScoped<QuestionDifficultyService>();
            services.AddScoped<UserContributionRatingService>();


        }
        public static void AddTheDbContext(this IServiceCollection services)
        {
            var dbhost = "192.168.1.105"; //Environment.GetEnvironmentVariable("DB_HOST");
            var dbname = "BilgiLigiContributionDB";// Environment.GetEnvironmentVariable("DB_NAME");
            var dbpassword = "Seda@123";// Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            services.AddDbContext<ContributionDbContext>(
                options => options.UseSqlServer(@$"Data Source={dbhost};Initial Catalog={dbname};User ID=sa;Password={dbpassword};Trust Server Certificate=True;Connect Timeout=30")
                //options => options.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BilgiLigiContestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            );
        }

    }
}

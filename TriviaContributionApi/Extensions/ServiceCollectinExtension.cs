using Microsoft.EntityFrameworkCore;
using TriviaContributionApi.DataLayer;
using TriviaContributionApi.DataLayer.Repositories.QuestionDifficulty_;
using TriviaContributionApi.DataLayer.Repositories.QuestionDraft_;
using TriviaContributionApi.DataLayer.Repositories.QuestionDraftDifficulty_;
using TriviaContributionApi.DataLayer.Repositories.QuestionDraftQuality_;

namespace TriviaContributionApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // data layer
            services.AddTransient<IContributionDbContext, ContributionDbContext>();
            services.AddTransient<IQuestionDraftRepository, QuestionDraftRepository>();
            services.AddTransient<IQuestionDifficultyRepository, QuestionDifficultyRepository>();
            services.AddTransient<IDraftDifficultyRepository, DraftDifficultyRepository>();
            services.AddTransient<IDraftQualityRepository, DraftQualityRepository>();
            services.AddTransient<IContributionDbContext, ContributionDbContext>();
            services.AddTransient<IContributionDbContext, ContributionDbContext>();

        }
        public static void AddTheDbContext(this IServiceCollection services)
        {
            var dbhost = "192.168.1.105"; //Environment.GetEnvironmentVariable("DB_HOST");
            var dbname = "TriviaContributionDB";// Environment.GetEnvironmentVariable("DB_NAME");
            var dbpassword = "Seda@123";// Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            services.AddDbContext<ContributionDbContext>(
                options => options.UseSqlServer(@$"Data Source={dbhost};Initial Catalog={dbname};User ID=sa;Password={dbpassword};Trust Server Certificate=True;Connect Timeout=30")
                //options => options.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TriviaContestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            );
        }

    }
}

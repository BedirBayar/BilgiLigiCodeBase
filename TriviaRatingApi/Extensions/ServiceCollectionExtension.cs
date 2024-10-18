using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TriviaRatingApi.DataLayer;
using TriviaRatingApi.DataLayer.Repositories.Award_;
using TriviaRatingApi.DataLayer.Repositories.Rank_;
using TriviaRatingApi.DataLayer.Repositories.Team_;
using TriviaRatingApi.DataLayer.Repositories.TeamAward_;
using TriviaRatingApi.DataLayer.Repositories.TeamRank_;
using TriviaRatingApi.DataLayer.Repositories.TeamRating_;
using TriviaRatingApi.DataLayer.Repositories.UserAward_;
using TriviaRatingApi.DataLayer.Repositories.UserRank_;
using TriviaRatingApi.DataLayer.Repositories.UserRating_;
using TriviaRatingApi.DataLayer.Repositories.UserTeam_;
using TriviaRatingApi.Services.Award_;
using TriviaRatingApi.Services.Rank_;
using TriviaRatingApi.Services.Team_;
using TriviaRatingApi.Services.TeamAward_;
using TriviaRatingApi.Services.TeamRank_;
using TriviaRatingApi.Services.TeamRating_;
using TriviaRatingApi.Services.UserAward_;
using TriviaRatingApi.Services.UserRank_;
using TriviaRatingApi.Services.UserRating_;
using TriviaRatingApi.Services.UserTeam_;


namespace TriviaSecurityApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //data layer
            services.AddTransient<IRatingDbContext, RatingDbContext>();
            services.AddTransient<IAwardRepository, AwardRepository>();
            services.AddTransient<IRankRepository, RankRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ITeamAwardRepository, TeamAwardRepository>();
            services.AddTransient<ITeamRankRepository, TeamRankRepository>();
            services.AddTransient<ITeamRatingRepository, TeamRatingRepository>();
            services.AddTransient<IUserRankRepository, UserRankRepository>();
            services.AddTransient<IUserRatingRepository, UserRatingRepository>();
            services.AddTransient<IUserAwardRepository, UserAwardRepository>();
            services.AddTransient<IUserTeamRepository, UserTeamRepository>();
            //service layer
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IRankService, RankService>();
            services.AddTransient<IAwardService, AwardService>();
            services.AddTransient<ITeamAwardService, TeamAwardService>();
            services.AddTransient<ITeamRankService, TeamRankService>();
            services.AddTransient<ITeamRatingService, TeamRatingService>();
            services.AddTransient<IUserAwardService, UserAwardService>();
            services.AddTransient<IUserRankService, UserRankService>();
            services.AddTransient<IUserRatingService, UserRatingService>();
            services.AddTransient<IUserTeamService, UserTeamService>();

        }
        public static void AddTheDbContext(this IServiceCollection services)
        {
            var dbhost = "192.168.1.105"; //Environment.GetEnvironmentVariable("DB_HOST");
            var dbname = "TriviaContestDB";// Environment.GetEnvironmentVariable("DB_NAME");
            var dbpassword = "Seda@123";// Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            services.AddDbContext<RatingDbContext>(

                      options => options.UseSqlServer(@$"Data Source={dbhost};Initial Catalog={dbname};User ID=sa;Password={dbpassword};Trust Server Certificate=True;Connect Timeout=30")
                   //options => options.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TriviaContestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                   );
        }

    }
}

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
            services.AddScoped<IRatingDbContext, RatingDbContext>();
            services.AddScoped<IAwardRepository, AwardRepository>();
            services.AddScoped<IRankRepository, RankRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamAwardRepository, TeamAwardRepository>();
            services.AddScoped<ITeamRankRepository, TeamRankRepository>();
            services.AddScoped<ITeamRatingRepository, TeamRatingRepository>();
            services.AddScoped<IUserRankRepository, UserRankRepository>();
            services.AddScoped<IUserRatingRepository, UserRatingRepository>();
            services.AddScoped<IUserAwardRepository, UserAwardRepository>();
            services.AddScoped<IUserTeamRepository, UserTeamRepository>();
            //service layer
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IRankService, RankService>();
            services.AddScoped<IAwardService, AwardService>();
            services.AddScoped<ITeamAwardService, TeamAwardService>();
            services.AddScoped<ITeamRankService, TeamRankService>();
            services.AddScoped<ITeamRatingService, TeamRatingService>();
            services.AddScoped<IUserAwardService, UserAwardService>();
            services.AddScoped<IUserRankService, UserRankService>();
            services.AddScoped<IUserRatingService, UserRatingService>();
            services.AddScoped<IUserTeamService, UserTeamService>();

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

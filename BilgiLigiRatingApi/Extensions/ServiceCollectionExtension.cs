using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BilgiLigiRatingApi.DataLayer;
using BilgiLigiRatingApi.DataLayer.Repositories.Award_;
using BilgiLigiRatingApi.DataLayer.Repositories.Rank_;
using BilgiLigiRatingApi.DataLayer.Repositories.Team_;
using BilgiLigiRatingApi.DataLayer.Repositories.TeamAward_;
using BilgiLigiRatingApi.DataLayer.Repositories.TeamRank_;
using BilgiLigiRatingApi.DataLayer.Repositories.TeamRating_;
using BilgiLigiRatingApi.DataLayer.Repositories.UserAward_;
using BilgiLigiRatingApi.DataLayer.Repositories.UserRank_;
using BilgiLigiRatingApi.DataLayer.Repositories.UserRating_;
using BilgiLigiRatingApi.DataLayer.Repositories.UserTeam_;
using BilgiLigiRatingApi.Services.Award_;
using BilgiLigiRatingApi.Services.Rank_;
using BilgiLigiRatingApi.Services.Team_;
using BilgiLigiRatingApi.Services.TeamAward_;
using BilgiLigiRatingApi.Services.TeamRank_;
using BilgiLigiRatingApi.Services.TeamRating_;
using BilgiLigiRatingApi.Services.UserAward_;
using BilgiLigiRatingApi.Services.UserRank_;
using BilgiLigiRatingApi.Services.UserRating_;
using BilgiLigiRatingApi.Services.UserTeam_;


namespace BilgiLigiSecurityApi.Extensions
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
            var dbname = "BilgiLigiRatingDB";// Environment.GetEnvironmentVariable("DB_NAME");
            var dbpassword = "Seda@123";// Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            services.AddDbContext<RatingDbContext>(

                      options => options.UseSqlServer(@$"Data Source={dbhost};Initial Catalog={dbname};User ID=sa;Password={dbpassword};Trust Server Certificate=True;Connect Timeout=30")
                   //options => options.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BilgiLigiContestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                   );
        }

    }
}

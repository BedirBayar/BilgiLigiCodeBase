using Microsoft.EntityFrameworkCore;
using BilgiLigiContestApi.DataAccess;
using BilgiLigiContestApi.DataAccess.Repositories.Category_;
using BilgiLigiContestApi.DataAccess.Repositories.Contest_;
using BilgiLigiContestApi.DataAccess.Repositories.ContestAward_;
using BilgiLigiContestApi.DataLayer.Repositories.ContestRule_;
using BilgiLigiContestApi.DataAccess.Repositories.ContestType_;
using BilgiLigiContestApi.DataAccess.Repositories.LeaderBoard_;
using BilgiLigiContestApi.DataAccess.Repositories.LeaderBoardTeam_;
using BilgiLigiContestApi.DataAccess.Repositories.LeaderBoardUser_;
using BilgiLigiContestApi.DataAccess.Repositories.Match_;
using BilgiLigiContestApi.DataAccess.Repositories.MatchQuestion_;
using BilgiLigiContestApi.DataAccess.Repositories.Question_;
using BilgiLigiContestApi.Services.Category_;
using BilgiLigiContestApi.Services.Contest_;
using BilgiLigiContestApi.Services.ContestRule_;
using BilgiLigiContestApi.Services.ContestType_;
using BilgiLigiContestApi.Services.LeaderBoard_;
using BilgiLigiContestApi.Services.Question_;
using BilgiLigiContestApi.Services.Match_;
using BilgiLigiContestApi.DataLayer.Repositories.ContestUser_;
using BilgiLigiContestApi.DataLayer.Repositories.ContestTeam_;

namespace BilgiLigiSecurityApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            // data layer
            services.AddScoped<IContestDbContext, ContestDbContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IContestRepository, ContestRepository>();
            services.AddScoped<IContestAwardRepository, ContestAwardRepository>();
            services.AddScoped<IContestRuleRepository, ContestRuleRepository>();
            services.AddScoped<IContestTypeRepository, ContestTypeRepository>();
            services.AddScoped<ILeaderBoardRepository, LeaderBoardRepository>();
            services.AddScoped<ILeaderBoardTeamRepository, LeaderBoardTeamRepository>();
            services.AddScoped<ILeaderBoardUserRepository, LeaderBoardUserRepository>();
            services.AddScoped<IUserMatchRepository, UserMatchRepository>();
            services.AddScoped<ITeamMatchRepository, TeamMatchRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IUserMatchQuestionRepository, UserMatchQuestionRepository>();
            services.AddScoped<IContestUserRepository, ContestUserRepository>();
            services.AddScoped<IContestTeamRepository, ContestTeamRepository>();
            //service layer
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContestService, ContestService>();
            services.AddScoped<IContestRuleService, ContestRuleService>();
            services.AddScoped<IContestTypeService, ContestTypeService>();
            services.AddScoped<ILeaderBoardService, LeaderBoardService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IUserMatchService, UserMatchService>();
            services.AddScoped<ITeamMatchService, TeamMatchService>();

        }
        public static void AddTheDbContext(this IServiceCollection services)
        {
            var dbhost = "192.168.1.105"; //Environment.GetEnvironmentVariable("DB_HOST");
            var dbname = "BilgiLigiContestDB";// Environment.GetEnvironmentVariable("DB_NAME");
            var dbpassword = "Seda@123";// Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            services.AddDbContext<ContestDbContext>(
                options => options.UseSqlServer(@$"Data Source={dbhost};Initial Catalog={dbname};User ID=sa;Password={dbpassword};Trust Server Certificate=True;Connect Timeout=30")
                //options => options.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BilgiLigiContestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            );
        }

    }
}

using Microsoft.EntityFrameworkCore;
using TriviaContestApi.DataAccess;
using TriviaContestApi.DataAccess.Repositories.Category_;
using TriviaContestApi.DataAccess.Repositories.Contest_;
using TriviaContestApi.DataAccess.Repositories.ContestAward_;
using TriviaContestApi.DataLayer.Repositories.ContestRule_;
using TriviaContestApi.DataAccess.Repositories.ContestType_;
using TriviaContestApi.DataAccess.Repositories.LeaderBoard_;
using TriviaContestApi.DataAccess.Repositories.LeaderBoardTeam_;
using TriviaContestApi.DataAccess.Repositories.LeaderBoardUser_;
using TriviaContestApi.DataAccess.Repositories.Match_;
using TriviaContestApi.DataAccess.Repositories.MatchQuestion_;
using TriviaContestApi.DataAccess.Repositories.Question_;
using TriviaContestApi.Services.Category_;
using TriviaContestApi.Services.Contest_;
using TriviaContestApi.Services.ContestRule_;
using TriviaContestApi.Services.ContestType_;
using TriviaContestApi.Services.LeaderBoard_;
using TriviaContestApi.Services.Question_;
using TriviaContestApi.Services.Match_;
using TriviaContestApi.DataLayer.Repositories.ContestUser_;
using TriviaContestApi.DataLayer.Repositories.ContestTeam_;

namespace TriviaSecurityApi.Extensions
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
            var dbname = "TriviaContestDB";// Environment.GetEnvironmentVariable("DB_NAME");
            var dbpassword = "Seda@123";// Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            services.AddDbContext<ContestDbContext>(
                options => options.UseSqlServer(@$"Data Source={dbhost};Initial Catalog={dbname};User ID=sa;Password={dbpassword};Trust Server Certificate=True;Connect Timeout=30")
                //options => options.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TriviaContestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
            );
        }

    }
}

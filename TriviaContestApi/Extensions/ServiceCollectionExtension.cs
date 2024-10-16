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
            services.AddTransient<IContestDbContext, ContestDbContext>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IContestRepository, ContestRepository>();
            services.AddTransient<IContestAwardRepository, ContestAwardRepository>();
            services.AddTransient<IContestRuleRepository, ContestRuleRepository>();
            services.AddTransient<IContestTypeRepository, ContestTypeRepository>();
            services.AddTransient<ILeaderBoardRepository, LeaderBoardRepository>();
            services.AddTransient<ILeaderBoardTeamRepository, LeaderBoardTeamRepository>();
            services.AddTransient<ILeaderBoardUserRepository, LeaderBoardUserRepository>();
            services.AddTransient<IUserMatchRepository, UserMatchRepository>();
            services.AddTransient<ITeamMatchRepository, TeamMatchRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IUserMatchQuestionRepository, UserMatchQuestionRepository>();
            services.AddTransient<IContestUserRepository, ContestUserRepository>();
            services.AddTransient<IContestTeamRepository, ContestTeamRepository>();
            //service layer
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IContestService, ContestService>();
            services.AddTransient<IContestRuleService, ContestRuleService>();
            services.AddTransient<IContestTypeService, ContestTypeService>();
            services.AddTransient<ILeaderBoardService, LeaderBoardService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IUserMatchService, UserMatchService>();
            services.AddTransient<ITeamMatchService, TeamMatchService>();

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

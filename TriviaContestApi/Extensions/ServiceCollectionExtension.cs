using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TriviaContestApi.DataAccess;

namespace TriviaSecurityApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IContestDbContext, ContestDbContext>();

        }
        public static void AddTheDbContext(this IServiceCollection services)
        {
            //var dbhost = Environment.GetEnvironmentVariable("DB_HOST");
            //var dbname = Environment.GetEnvironmentVariable("DB_NAME");
            //var dbpassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
            services.AddDbContext<ContestDbContext>(
                       
                     // options => options.UseSqlServer(@$"Data Source={dbhost};Initial Catalog={dbname};User ID=sa;Password={dbpassword};Trust Server Certificate=True;Connect Timeout=30")
                       options => options.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TriviaContestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                   );
        }

    }
}

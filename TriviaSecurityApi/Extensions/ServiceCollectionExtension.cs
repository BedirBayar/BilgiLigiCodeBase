using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TriviaSecurityApi.DataLayer;
using TriviaSecurityApi.DataLayer.Repositories;
using TriviaSecurityApi.Services;
using TriviaSecurityApi.Services.User;

namespace TriviaSecurityApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddTransient<IEncryptionService, EncryptionService>();
            services.AddTransient<ISecurityDbContext, SecurityDbContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            // services.AddTransient<IIdentityService, IdentityService>();

        }
        public static void AddTheDbContext(this IServiceCollection services)
        {
            services.AddDbContext<SecurityDbContext>(
                       options => options.UseSqlServer(@$"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TriviaSecurityDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                   );
        }

    }
}

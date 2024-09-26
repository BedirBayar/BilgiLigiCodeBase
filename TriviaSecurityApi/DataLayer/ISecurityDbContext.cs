using Microsoft.EntityFrameworkCore;
using TriviaSecurityApi.DataLayer.Entities;

namespace TriviaSecurityApi.DataLayer
{
    public interface ISecurityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

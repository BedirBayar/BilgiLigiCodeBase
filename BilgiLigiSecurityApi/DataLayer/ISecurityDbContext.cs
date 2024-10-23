using Microsoft.EntityFrameworkCore;
using BilgiLigiSecurityApi.DataLayer.Entities;

namespace BilgiLigiSecurityApi.DataLayer
{
    public interface ISecurityDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}

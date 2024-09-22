using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using TriviaSecurityApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml;

namespace TriviaSecurityApi.DataLayer
{
   
    public class SecurityDbContext : DbContext, ISecurityDbContext
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options) : base(options)
        {
            
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            return await base.SaveChangesAsync(cancellationToken);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(e => e.Rating).HasPrecision(38, 18);
            modelBuilder.Entity<User>().Property(e => e.ContributionRating).HasPrecision(38, 18);
        }
    }
    
}

using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml;
using TriviaSecurityApi.DataLayer.Entities;

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
            //QueryFilters
            modelBuilder.Entity<User>().HasQueryFilter(e=>!e.IsArchived);
            modelBuilder.Entity<Role>().HasQueryFilter(e=>!e.IsArchived);
            //


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u=> u.Id)
                    .UseIdentityColumn(1, 1);

                // RoleId - Foreign Key to Role Table
                entity.HasOne(u => u.Role)
                    .WithMany(r => r.Users)
                    .HasForeignKey(u => u.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                // ReportedRating
                entity.Property(u => u.ReportedRating)
                    .HasDefaultValue(0);

                // IsBanned
                entity.Property(u => u.IsBanned)
                    .HasDefaultValue(false);

                // Index on Email
                entity.HasIndex(u => u.Email)
                    .IsUnique();
                // Index on UserName
                entity.HasIndex(u => u.UserName)
                    .IsUnique();
            });

            modelBuilder.Entity<Role>(entity =>
            {

                // Id - Primary Key
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Id)
                    .UseIdentityColumn(1,1);
                // Name
                entity.Property(r => r.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                // Index on Name
                entity.HasIndex(r => r.Name)
                    .IsUnique();
            });
        }
    }
    
}

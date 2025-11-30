using MailroomManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MailroomManagement.Infrastructure.Data
{
    namespace MailroomManagement.Infrastructure.Data
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<User> Users { get; set; }
            public DbSet<Organization> Organizations { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Letter> Letters { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Configure relationships and constraints
                modelBuilder.Entity<User>()
                    .HasOne(u => u.Organization)
                    .WithMany(o => o.Users)
                    .HasForeignKey(u => u.OrganizationId);

                modelBuilder.Entity<User>()
                    .HasOne(u => u.Department)
                    .WithMany(d => d.Users)
                    .HasForeignKey(u => u.DepartmentId);

                modelBuilder.Entity<Department>()
                    .HasOne(d => d.Organization)
                    .WithMany(o => o.Departments)
                    .HasForeignKey(d => d.OrganizationId);

                modelBuilder.Entity<User>()
                    .HasMany(u => u.Letters)
                    .WithOne(l => l.User)
                    .HasForeignKey(l => l.UserId);
            }
        }
    }
}

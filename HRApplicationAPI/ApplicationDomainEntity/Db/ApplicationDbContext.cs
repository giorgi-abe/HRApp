using ApplicationDatabaseModels;
using ApplicationDatabaseModels.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationDomainEntity.Db
{
    public class ApplicationDbContext : IdentityDbContext<User,UserRole,string>
    {
        public ApplicationDbContext() { }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source=DESKTOP-UR28SV7;Database=HRApp;Trusted_Connection=true;MultipleActiveResultSets=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().Property(t => t.Email).IsRequired();
            modelBuilder.Entity<User>().Property(t => t.PasswordHash).IsRequired();
            modelBuilder.Entity<User>().Property(t => t.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(t => t.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasMany<Employee>(g => g.Employees)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

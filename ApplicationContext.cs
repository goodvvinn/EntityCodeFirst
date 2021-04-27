using System;
using EntityCodeFirst.Entities;
using EntityCodeFirst.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntityCodeFirst
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Title> Title { get; set; }
        public DbSet<EmployeeProject> EmployeeProject { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}

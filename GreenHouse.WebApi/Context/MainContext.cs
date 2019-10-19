using System;
using GreenHouse.Core.Models.Enums;
using GreenHouse.Core.Models.MainModels;
using GreenHouse.Core.Models.Tools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GreenHouse.Context
{
    public class MainContext : DbContext
    {
        private readonly AppSettings m_appSettings;

        public MainContext(DbContextOptions options, IOptions<AppSettings> appSettings) : base(options) =>
            m_appSettings = appSettings.Value;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserFriend> Friends { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Contributor> Contributors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            optionsBuilder.UseMySql(m_appSettings.ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetPrimaryKeys(modelBuilder);
            SetForeignKeys(modelBuilder);
            SetAllIndex(modelBuilder);
            SetEnumConversion(modelBuilder);
            SetDefaultValues(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void SetPrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(t => t.Id);
            modelBuilder.Entity<Report>().HasKey(t => t.Id);
            modelBuilder.Entity<UserFriend>().HasKey(t => t.Id);
            modelBuilder.Entity<Contributor>().HasKey(t => t.Id);
            modelBuilder.Entity<Schedule>().HasKey(t => t.Id);
        }

        private static void SetForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFriend>().HasOne(t => t.User)
                .WithMany(t => t.Friends)
                .HasForeignKey(t => t.UserId);
            
            modelBuilder.Entity<Report>().HasOne(t => t.Account)
                .WithMany(t => t.UserReports)
                .HasForeignKey(t => t.UserId);

            modelBuilder.Entity<Schedule>().HasOne(t => t.Report)
                .WithOne(t => t.Schedule)
                .HasForeignKey<Schedule>(t => t.ReportId);

            modelBuilder.Entity<Contributor>().HasOne(t => t.Report)
                .WithMany(t => t.Contributors)
                .HasForeignKey(t => t.ReportId);
        }

        private static void SetAllIndex(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasIndex(t => t.Id);

            modelBuilder.Entity<Report>().HasIndex(t => t.Id);
            modelBuilder.Entity<Report>().HasIndex(t => t.UserId);

            modelBuilder.Entity<UserFriend>().HasIndex(t => t.Id);
            modelBuilder.Entity<UserFriend>().HasIndex(t => t.UserId);
            modelBuilder.Entity<UserFriend>().HasIndex(t => t.FriendId);
            
            modelBuilder.Entity<Schedule>().HasIndex(t => t.Id);
            modelBuilder.Entity<Schedule>().HasIndex(t => t.ReportId);
            
            modelBuilder.Entity<Contributor>().HasIndex(t => t.Id);
            modelBuilder.Entity<Contributor>().HasIndex(t => t.ReportId);
            modelBuilder.Entity<Contributor>().HasIndex(t => t.UserId);
        }

        private static void SetEnumConversion(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Property(t => t.Type).HasConversion(
                e => e.ToString(),
                p => (AccountType) Enum.Parse(typeof(AccountType), p)
            ).HasColumnType("varchar(40)");

            modelBuilder.Entity<Report>().Property(t => t.State).HasConversion(
                e => e.ToString(),
                p => (DeforestState) Enum.Parse(typeof(DeforestState), p)
            ).HasColumnType("varchar(40)");
        }

        private static void SetDefaultValues(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().Property(t => t.Type).HasDefaultValue(AccountType.User);
        }
    }
}
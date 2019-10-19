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
        
            
        }

        private static void SetForeignKeys(ModelBuilder modelBuilder)
        {
       
        }

        private static void SetAllIndex(ModelBuilder modelBuilder)
        {
        
        }

        private static void SetEnumConversion(ModelBuilder modelBuilder)
        {
         
        }

        private static void SetDefaultValues(ModelBuilder modelBuilder)
        {
    
        }
    }
}
﻿using Microsoft.EntityFrameworkCore;

namespace Cloudweather.Report.DataAccess
{
    public class WeatherReportDbContext : DbContext
    {
        public WeatherReportDbContext() { }
        public WeatherReportDbContext(DbContextOptions opts) : base(opts) { }

        public DbSet<WeatherReport> WeatherReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SnakeCaseIdentityTableNames(modelBuilder);
        }

        private static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherReport>(b => { b.ToTable("weather_report"); });
        }
    }
}

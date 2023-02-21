using Microsoft.EntityFrameworkCore;

namespace Cloudweather.Pricipitation.DataAcces
{
    public class PrecipDbContext :DbContext
    {
        public PrecipDbContext() { }
        public PrecipDbContext(DbContextOptions options): base(options) { }

        public DbSet<Precipitation> Pricipitation { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }

        private static void SnakeCaseIdentityTableNames(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Precipitation>(b => { b.ToTable("precipitation"); });
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace api.Contexts
{
    public class HouseDbContext : DbContext
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options) : base(options) {}
        public DbSet<Entities.House> Houses => Set<Entities.House>();

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // Db file:
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);

            builder.UseSqlite($"Data Source={Path.Join(path, "XYZZZYX.db")}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            HouseDbContextSeedData.Seed(builder);
        }
    }
}
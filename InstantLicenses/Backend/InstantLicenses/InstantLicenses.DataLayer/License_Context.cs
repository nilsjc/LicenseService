using InstantLicenses.DataLayer.DbModels;
using Microsoft.EntityFrameworkCore;

namespace InstantLicenses.DataLayer
{
    public class License_Context : DbContext
    {
        public DbSet<License> Licenses { get; set; }
        public string DbPath { get; }

        public License_Context()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "licenses_v3.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<License>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        }

    }
}

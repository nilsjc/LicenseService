using InstantLicenses.DataLayer.DbModels;
using Microsoft.EntityFrameworkCore;

namespace InstantLicenses.DataLayer
{
    internal class LicenseContext : DbContext
    {
        public DbSet<License> Licenses { get; set; }
        public DbSet<LicenseRent> Rents { get; set; }
        public string DbPath { get; }

        public LicenseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "licenses.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LicenseRent>()
                .HasOne(r => r.License)
                .WithMany(x => x.Rents);
        }
    }
}

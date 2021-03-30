using Biotronic.Poultry.Data.Model;
using Biotronic.Poultry.Utilities;
using Biotronic.Poultry.Utilities.Database;
using Microsoft.EntityFrameworkCore;

namespace Biotronic.Poultry.Data
{
    public class PoultryDbContext : BaseDbContext<PoultryDbContext>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<DayRecord> Days { get; set; }
        public DbSet<DayComment> DayComments { get; set; }
        public DbSet<Brood> Broods { get; set; }
        public DbSet<BroodComment> BroodComments { get; set; }
        public DbSet<BroodTreatment> BroodTreatments { get; set; }
        public DbSet<BroodDisinfection> BroodDisinfections { get; set; }
        public DbSet<BroodDelivery> BroodDeliveries { get; set; }
        public DbSet<DeliveryComment> DeliveryComments { get; set; }
        public DbSet<BroodFeed> BroodFeeds { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }
        public DbSet<Hatchery> Hatcheries { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Hybrid> Hybrids { get; set; }
        public DbSet<FarmAccess> FarmAccess { get; set; }

        public PoultryDbContext() { }

        public PoultryDbContext(DbContextOptions<PoultryDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder<PoultryConfiguration>()
                .UseAppSettings();
            ConnectionString = builder.Build().ConnectionString;
            base.OnConfiguring(optionsBuilder);
        }
    }
}

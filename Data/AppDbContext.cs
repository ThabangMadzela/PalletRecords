/// <summary>
/// AppDbContext is the Entity Framework Core database context for the PalletRecords application. 
/// It manages the entities related to pallets and their configurations, including CRUD operations 
/// and database migrations.
/// </summary>
/// <author>Thabang Thubane</author>
/// <version>v1</version>
/// 

using Microsoft.EntityFrameworkCore;
using PalletRecords.Models;

namespace PalletRecords.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Pallet> Pallets { get; set; }
        public DbSet<PalletConfig> PalletConfigs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalletConfig>()
                .HasOne<Pallet>()
                .WithMany()
                .HasForeignKey(i => i.PalletId);

            base.OnModelCreating(modelBuilder);
        }
    }
}

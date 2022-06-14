using System.Reflection.Metadata;
using inventory.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace inventory.DataModels
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {
        }

        public DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>()
                .HasNoKey();
            modelBuilder.Entity<Binlocation>()
                .HasMany(b => b.Stocks)
                .WithOne();
            base.OnModelCreating(modelBuilder);
        }
    }
}

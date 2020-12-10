using Microsoft.EntityFrameworkCore;
using Trucks.Api.Model.Models;

namespace Trucks.Api.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TruckInventory> TruckInventories { get; set; }
        public DbSet<TruckCategory> TruckCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>(entity => {
                entity.Property(t => t.Name).IsRequired();
                entity.Property(t => t.Description).IsRequired();
                entity.Property(t => t.Price).IsRequired();
                entity.HasOne(t => t.TruckInventory)
                      .WithOne(ti => ti.Truck)
                      //.HasForeignKey<Truck>("TruckInventoryId")
                      .HasForeignKey<TruckInventory>(ti => ti.TruckInventoryId)
                      ;
            });

            modelBuilder.Entity<Photo>(entity => {
                entity.Property(p => p.PhotoPath).IsRequired();
                entity.HasOne(p => p.Truck)
                      .WithMany(t => t.Photos)
                      .HasForeignKey(p => p.TruckId);
            });

            modelBuilder.Entity<Category>(entity => {
                entity.Property(t => t.Name).IsRequired();
            });

            modelBuilder.Entity<TruckInventory>(entity => {
                entity.Property(ti => ti.Quantity).IsRequired();


            });
            modelBuilder.Entity<TruckCategory>(entity => {
                entity.HasKey(tc => new { tc.TruckId, tc.CategoryId });
                entity.HasOne(tc => tc.Category)
                      .WithMany(c => c.TruckCategories)
                      .HasForeignKey(tc => tc.CategoryId);
                entity.HasOne(tc => tc.Truck)
                      .WithMany(t => t.TruckCategories)
                      .HasForeignKey(tc => tc.TruckId);

            });



        }

    }
}

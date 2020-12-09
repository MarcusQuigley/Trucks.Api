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
            });

            modelBuilder.Entity<Photo>(entity => {
                entity.Property(t => t.PhotoPath).IsRequired();
            });

            modelBuilder.Entity<Category>(entity => {
                entity.Property(t => t.Name).IsRequired();
            });

            modelBuilder.Entity<TruckInventory>(entity => {
                entity.Property(t => t.Quantity).IsRequired();
            });

            //compositeKey
            modelBuilder.Entity<TruckCategory>().HasKey(tc => new { tc.CategoryId, tc.TruckId });


        }

    }
}

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

        public DbSet<TruckCategory> TruckCategories { get; set; }

        public DbSet<Photo> TruckPhotos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>(entity => {
                entity.Property(t => t.Name).IsRequired();
                entity.Property(t => t.Description).IsRequired();
                entity.Property(t => t.Price).IsRequired();
                entity.HasMany(d => d.Photos)
                              .WithOne(f => f.Truck)
                              .HasForeignKey(d => d.TruckId);
                //entity.HasOne(t => t.TruckInventory)
                //      .WithOne(ti => ti.Truck)
                //      .HasForeignKey<Truck>(t => t.TruckInventoryId)
                //      ;
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

            modelBuilder.Entity<TruckCategory>(entity => {
                entity.HasKey(tc => new { tc.TruckId, tc.CategoryId });
                entity.HasOne(tc => tc.Category)
                      .WithMany(c => c.TruckCategories)
                      .HasForeignKey(tc => tc.CategoryId);
                entity.HasOne(tc => tc.Truck)
                      .WithMany(t => t.TruckCategories)
                      .HasForeignKey(tc => tc.TruckId);

            });

            modelBuilder.Entity<SalesOrder>(entity => {
                entity.Property(so => so.OrderDate).IsRequired();
                entity.Property(so => so.CustomerDetailsId).IsRequired();
                entity.Property(so => so.TotalDue).IsRequired();
                entity.Property(so => so.SalesOrderDetailId).IsRequired();
                entity.HasOne(so => so.SalesDetail)
                      .WithOne(sod => sod.SalesOrder)
                      .HasForeignKey<SalesOrderDetail>(sod => sod.SalesOrderDetailId);
            });

            modelBuilder.Entity<SalesOrderDetail>(entity => {
                entity.Property(sod => sod.Quantity).IsRequired();
                entity.HasOne(sod => sod.Truck)
                              .WithMany(t => t.Sales)
                              .HasForeignKey(p => p.TruckId);
            });

        }
    }
}

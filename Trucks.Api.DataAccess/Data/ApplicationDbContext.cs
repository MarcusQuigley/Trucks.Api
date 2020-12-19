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
        public DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Truck>(entity => {
                entity.Property(t => t.Name).IsRequired();
                entity.Property(t => t.Description).IsRequired();
                entity.Property(t => t.Price).IsRequired();
                entity.HasMany(d => d.Photos)
                              .WithOne(f => f.Truck)
                              .HasForeignKey(d => d.TruckId);
                //entity.HasMany(t => t.Sales)
                //              .WithOne(sod => sod.Truck)
                //              .HasForeignKey(sod => sod.TruckId);
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
                entity.Property(t => t.IsMini).HasDefaultValue(false);
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

            modelBuilder.Entity<SalesOrderHeader>(entity => {
                entity.Property(so => so.OrderDate).IsRequired();
                entity.Property(so => so.CustomerEmail).IsRequired();
                entity.Property(so => so.TotalDue).IsRequired();
                //entity.Property(so => so.SalesOrderDetailId).IsRequired();
                entity.HasMany(so => so.SalesDetails)
                             .WithOne(sod => sod.SalesOrder)
                             .HasForeignKey(sod => sod.SalesOrderDetailId);

            });

            modelBuilder.Entity<SalesOrderDetail>(entity => {
                entity.Property(sod => sod.Quantity).IsRequired();
                entity.HasOne(sod => sod.SalesOrder)
                     .WithMany(so => so.SalesDetails)
                     .HasForeignKey(sod => sod.SalesOrderDetailId);
                //entity.HasOne(sod => sod.Truck)
                //              .WithMany(t => t.Sales)
                //              .HasForeignKey(p => p.TruckId);
            });

        }
    }
}

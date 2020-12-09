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
            //compositeKey
            modelBuilder.Entity<TruckCategory>().HasKey(tc => new { tc.CategoryId, tc.TruckId });


        }

    }
}

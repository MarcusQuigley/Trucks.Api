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
    }
}

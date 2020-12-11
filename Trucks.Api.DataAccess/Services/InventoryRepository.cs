using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Trucks.Api.DataAccess.Data;
using Trucks.Api.Model.Models;

namespace Trucks.Api.DataAccess.Services
{
    public class InventoryRepository : IInventoryRepository
    {

        private ApplicationDbContext _context;
        // private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<InventoryRepository> _logger;
        private CancellationTokenSource _cancelToken;

        public InventoryRepository(ApplicationDbContext context, ILogger<InventoryRepository> logger)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private async Task<bool> InventoryExistsAsync(TruckInventory inventory)
        {
            return (await _context.TruckInventories.AnyAsync(ti => ti.TruckInventoryId == inventory.TruckInventoryId));
        }

        public async Task<IEnumerable<TruckInventory>> GetInventoriesAsync()
        {
            return await _context.TruckInventories.ToListAsync();
        }

        public async Task<IEnumerable<TruckInventory>> GetInventoriesByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<TruckInventory> GetInventoryAsync(int truckId)
        {
            return await _context.TruckInventories.FirstOrDefaultAsync(i => i.TruckInventoryId == truckId);
        }



        public async Task AddInventoryAsync(TruckInventory inventory)
        {
            inventory.ModifiedDate = DateTime.Now;
            await _context.TruckInventories.AddAsync(inventory);
        }

        public async Task DeleteInventoryAsync(TruckInventory inventory)
        {
            if (await InventoryExistsAsync(inventory))
                _context.Remove(inventory);
        }


        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task UpdateInventory(TruckInventory inventory)
        {
            throw new NotImplementedException();
        }
    }
}

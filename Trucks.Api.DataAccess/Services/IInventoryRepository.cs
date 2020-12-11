using System.Collections.Generic;
using System.Threading.Tasks;
using Trucks.Api.Model.Models;

namespace Trucks.Api.DataAccess.Services
{
    public interface IInventoryRepository
    {

        Task<TruckInventory> GetInventoryAsync(int truckId);
        Task<IEnumerable<TruckInventory>> GetInventoriesByCategoryAsync(int categoryId);
        Task<IEnumerable<TruckInventory>> GetInventoriesAsync();
        Task AddInventoryAsync(TruckInventory inventory);
        Task DeleteInventoryAsync(TruckInventory inventory);
        Task UpdateInventory(TruckInventory inventory);

        Task<bool> SaveChangesAsync();


    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Trucks.Api.Model.Models;

namespace Trucks.Api.DataAccess.Services
{
    public interface ITrucksRepository
    {

        Task<IEnumerable<Truck>> GetTrucksAsync();


        Task<IEnumerable<Truck>> GetTrucksByCategoryAsync(int categoryId);
        Task<IEnumerable<Truck>> GetHiddenTrucksAsync();


        Task<Truck> GetTruckAsync(int truckId);

        Task AddTruckAsync(Truck truck);
        Task DeleteTruckAsync(Truck truck);

        void AddTruckCategory(int truckId, int categoryId);
        Task AddTruckPhotoAsync(Photo truckPhoto);
        Task UpdateDefaultPhotoAsync(Photo truckPhoto);


        Task<bool> SaveChangesAsync();

    }
}

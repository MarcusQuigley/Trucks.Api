using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Trucks.Api.DataAccess.Data;
using Trucks.Api.Model.Models;


namespace Trucks.Api.DataAccess.Services
{
    public class TrucksRepository : ITrucksRepository
    {
        private ApplicationDbContext _context;
        //private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<TrucksRepository> _logger;
        private CancellationTokenSource _cancelToken;

        public TrucksRepository(ApplicationDbContext context,
            ILogger<TrucksRepository> logger)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            //      this._httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        private async Task<bool> TruckExistsAsync(int truckId)
        {
            return await _context.Trucks.AnyAsync(t => t.TruckId == truckId);
        }

        public async Task<IEnumerable<Truck>> GetHiddenTrucksAsync()
        {
            return await _context.Trucks.Where(t => t.Hidden == true)
                                        .Include(t => t.TruckCategories)
                                        .ThenInclude(t => t.Category)
                                        .Include(t => t.Photos)
                                        .ToListAsync();
        }

        public async Task<Truck> GetTruckAsync(int truckId)
        {
            return await _context.Trucks.Include(t => t.TruckCategories)
                                        .ThenInclude(t => t.Category)
                                        // .Include(t => t.)
                                        .Include(t => t.Photos)

                                        .FirstOrDefaultAsync(t => t.TruckId == truckId);

        }

        public async Task<IEnumerable<Truck>> GetTrucksAsync()
        {
            return await _context.Trucks.Where(t => t.Hidden == false)
                                        .Include(t => t.TruckCategories)
                                        .ThenInclude(t => t.Category)
                                        .Include(t => t.Photos)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Truck>> GetTrucksByCategoryAsync(int categoryId)
        {
            return await _context.Trucks.Where(t => t.Hidden == false)
                                        .Where(t => t.TruckCategories.Any(c => c.CategoryId == categoryId))
                                        .Include(t => t.TruckCategories)
                                        .ThenInclude(t => t.Category)
                                        .Include(t => t.Photos)
                                        .ToListAsync();
        }
        public async Task AddTruckAsync(Truck truck)
        {

            if (truck == null) {
                throw new ArgumentNullException(nameof(truck));
            }
            foreach (var category in truck.TruckCategories) {
                category.TruckId = truck.TruckId;

            }
            foreach (var photo in truck.Photos) {
                photo.TruckId = truck.TruckId;
                //      photo.TruckPhotoId = Guid.NewGuid();
            }
            await _context.Trucks.AddAsync(truck);
        }

        //public void AddTruckCategory(int truckId, int categoryId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task AddTruckPhotoAsync(Photo truckPhoto)
        {
            if (truckPhoto == null)
                throw new ArgumentNullException(nameof(truckPhoto));

            if (await TruckExistsAsync(truckPhoto.TruckId)) {
                await _context.TruckPhotos.AddAsync(truckPhoto);
                if (!await HasTruckDefaultPhoto(truckPhoto.TruckId))
                    await UpdateDefaultPhotoAsync(truckPhoto);
            }
        }

        public async Task UpdateDefaultPhotoAsync(Photo truckPhoto)
        {
            if (truckPhoto == null)
                throw new ArgumentNullException(nameof(truckPhoto));

            var truck = await GetTruckAsync(truckPhoto.TruckId);
            if (truck != null) {
                truck.DefaultPhotoPath = truckPhoto.PhotoPath;
                _context.Trucks.Update(truck);
            }

        }
        public void UpdateTruck(Truck truck)
        {
            //Nothing to add. ef will note that the record is dirty. Need to call Save though..
        }

        private async Task<bool> HasTruckDefaultPhoto(int truckId)
        {
            if (await TruckExistsAsync(truckId))
                return _context.Trucks.Where(t => t.TruckId == truckId)
                                      .Where(t => !string.IsNullOrEmpty(t.DefaultPhotoPath))
                                      .Any();
            return false;
        }

        public async Task DeleteTruckAsync(Truck truck)
        {
            throw new NotImplementedException();
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public async Task<bool> SaveChangesAsync()
        {

            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task AddSaleAsync(SalesOrderDetail salesDetail)
        {
            throw new NotImplementedException();
            //if (salesDetail == null)
            //    throw new ArgumentNullException(nameof(salesDetail));

            //if (await TruckExistsAsync(salesDetail.TruckId)) {
            //    salesDetail.ModifiedDate = DateTime.Now;
            //    await _context.SalesOrderHeader.AddAsync(salesDetail);

            //}
        }
    }
}

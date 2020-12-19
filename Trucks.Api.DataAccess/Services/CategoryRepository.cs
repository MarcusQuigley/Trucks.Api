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
    public class CategoryRepository : ICategoryRepository, IDisposable
    {
        private ApplicationDbContext _context;
        // private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CategoryRepository> _logger;
        private CancellationTokenSource _cancelToken;

        public CategoryRepository(ApplicationDbContext context, ILogger<CategoryRepository> logger)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await _context.Categories.AnyAsync(c => c.CategoryId == categoryId);
        }

        private async Task<bool> TruckExistsAsync(int truckId)
        {
            return await _context.Trucks.AnyAsync(t => t.TruckId == truckId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByTypeAsync(bool isMini)
        {
            return await _context.Categories.Where(c => c.IsMini == isMini)
                                            .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (category == null) {
                throw new ArgumentNullException(nameof(category));
            }
            await _context.Categories.AddAsync(category);
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            if (await CategoryExistsAsync(category.CategoryId))
                _context.Categories.Remove(category);
        }

        public async Task AddTruckCategory(TruckCategory truckCategory)
        {
            if (truckCategory == null)
                throw new ArgumentNullException(nameof(truckCategory));

            if (await CategoryExistsAsync(truckCategory.CategoryId) && await TruckExistsAsync(truckCategory.TruckId)) {
                await _context.TruckCategories.AddAsync(truckCategory);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                if (_context != null) {
                    _context.Dispose();
                    _context = null;
                }
                if (_cancelToken != null) {
                    _cancelToken.Dispose();
                    _cancelToken = null;
                }
            }
        }


    }
}

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

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        public void AddCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void AddTruckCategory(TruckCategory truckCategory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
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

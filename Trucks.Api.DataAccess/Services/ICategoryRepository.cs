﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Trucks.Api.Model.Models;

namespace Trucks.Api.DataAccess.Services
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesByTypeAsync(bool isMini);
        Task<Category> GetCategoryAsync(int categoryId);
        Task AddCategoryAsync(Category category);
        void UpdateCategory(Category category);
        Task DeleteCategoryAsync(Category category);
        Task AddTruckCategory(TruckCategory truckCategory);
        Task<bool> SaveChangesAsync();
    }
}

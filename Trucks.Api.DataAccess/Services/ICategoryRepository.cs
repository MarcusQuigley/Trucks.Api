using System.Collections.Generic;
using System.Threading.Tasks;
using Trucks.Api.Model.Models;

namespace Trucks.Api.DataAccess.Services
{
    public interface ICategoryRepository
    {
        // IEnumerable<Category> GetCategories();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        //Category GetCategory(int categoryId);
        Task<Category> GetCategoryAsync(int categoryId);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        void AddTruckCategory(TruckCategory truckCategory);
        Task<bool> SaveChangesAsync();
    }
}

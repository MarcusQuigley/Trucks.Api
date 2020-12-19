using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trucks.Api.ControllerFilters;
using Trucks.Api.DataAccess.Services;
using Trucks.Api.Dto;
using Trucks.Api.Model.Models;

namespace Trucks.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this._categoryRepository = categoryRepository ?? throw new ArgumentNullException(nameof(categoryRepository));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [CategoriesResultFilter]
        public async Task<ActionResult> GetCategoriesAsync()
        {
            var categoriesModels = await _categoryRepository.GetCategoriesAsync();
            return Ok(categoriesModels);

        }

        [HttpGet("{isMini:bool}")]
        [CategoriesResultFilter]
        public async Task<ActionResult> GetCategoriesByTypeAsync(bool isMini)
        {
            var categoriesModels = await _categoryRepository.GetCategoriesByTypeAsync(isMini);
            return Ok(categoriesModels);

        }

        [HttpGet("{categoryId:int}", Name = "GetCategory")]
        [CategoryResultFilter]
        public async Task<ActionResult> GetCategoryAsync(int categoryId)
        {
            var categoryModel = await _categoryRepository.GetCategoryAsync(categoryId);
            return Ok(categoryModel);

        }

        [HttpPost]
        public async Task<ActionResult> CreateCategoryAsync(CategoryDto category)
        {
            if (category == null) return BadRequest();
            var categoryModel = _mapper.Map<Category>(category);
            await _categoryRepository.AddCategoryAsync(categoryModel);
            if (await _categoryRepository.SaveChangesAsync() != false) {
                var categoryDto = _mapper.Map<CategoryDto>(categoryModel);
                return CreatedAtRoute("GetCategory", new { categoryId = categoryDto.CategoryId }, categoryDto);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("truckcategory")]
        public async Task<ActionResult> CreateTruckCategory([FromBody] Dto.TruckCategoryDto truckCategoryDto)
        {
            if (truckCategoryDto == null) return BadRequest();
            var truckCategory = _mapper.Map<TruckCategory>(truckCategoryDto);
            await _categoryRepository.AddTruckCategory(truckCategory);
            if (await _categoryRepository.SaveChangesAsync() != false)
                return NoContent();
            return BadRequest();

        }
        [HttpDelete("{categoryId:int}")]
        public async Task<ActionResult> DeleteCategoryAsync(int categoryId)
        {
            // var categoryModel = _mapper.Map<Category>(category);
            var categoryModel = await _categoryRepository.GetCategoryAsync(categoryId);
            if (categoryModel == null)
                return NotFound();
            await _categoryRepository.DeleteCategoryAsync(categoryModel);
            if (await _categoryRepository.SaveChangesAsync() != false)
                return NoContent();
            return BadRequest();
        }

    }
}

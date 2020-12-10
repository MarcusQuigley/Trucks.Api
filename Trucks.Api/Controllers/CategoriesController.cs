using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Trucks.Api.ControllerFilters;
using Trucks.Api.DataAccess.Services;

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
        public async Task<ActionResult> GetCategories()
        {
            var categoriesModels = await _categoryRepository.GetCategoriesAsync();
            return Ok(categoriesModels);

        }

    }
}

using AutoMapper;
using Trucks.Api.Model.Models;

namespace Trucks.Api.Mapping
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<Category, Dto.CategoryDto>();
            CreateMap<Dto.CategoryDto, Category>()
                .ReverseMap();

            //CreateMap<TruckCategory, Dto.TruckCategoryDto>();
            //CreateMap<Dto.TruckCategoryDto, TruckCategory>()
            //    .ReverseMap();

        }
    }
}

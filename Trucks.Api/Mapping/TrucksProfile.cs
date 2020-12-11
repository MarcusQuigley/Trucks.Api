using AutoMapper;
using Trucks.Api.Model.Models;

namespace Trucks.Api.Mapping
{
    public class TrucksProfile : Profile
    {
        public TrucksProfile()
        {
            CreateMap<Truck, Dto.TruckDto>();
            CreateMap<Dto.TruckDto, Truck>()
                .ReverseMap();

            //CreateMap<TruckCategory, Dto.TruckCategoryDto>();
            //CreateMap<Dto.TruckCategoryDto, TruckCategory>()
            //    .ReverseMap();

            CreateMap<TruckInventory, Dto.TruckInventoryDto>();
            CreateMap<Dto.TruckInventoryDto, TruckInventory>()
                .ReverseMap();

        }
    }
}

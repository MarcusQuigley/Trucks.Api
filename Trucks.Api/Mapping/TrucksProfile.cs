using AutoMapper;
using System.Linq;
using Trucks.Api.Model.Models;

namespace Trucks.Api.Mapping
{
    public class TrucksProfile : Profile
    {
        public TrucksProfile()
        {
            CreateMap<Truck, Dto.TruckDto>()
                .ForMember(
                    dto => dto.Categories,
                    opt => opt.MapFrom(
                        t => t.TruckCategories.Select(tc => tc.Category)))
                    ;

            CreateMap<Dto.TruckDto, Truck>()
                .ForMember(
                    t => t.TruckCategories,
                    opt => opt.MapFrom(dto => dto.TruckCategories))
                .AfterMap((dto, model) => {
                    foreach (var tc in model.TruckCategories)
                        tc.Truck = model;
                });
            //.ReverseMap();

        }
    }
}
